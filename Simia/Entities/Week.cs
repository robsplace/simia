using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace Simia.Entities
{
    [Serializable()]
    public class Week
    {
        public BindingList<Game> Games { get; set; } = new BindingList<Game>();
        public int NumTeasers { get; set; }
        public Dictionary<User, Dictionary<Game, Pick>> Picks { get; set; } = new Dictionary<User, Dictionary<Game, Pick>>();
        public Dictionary<User, int> Scores { get; set; } = new Dictionary<User, int>();

        public void UpdateScores(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                UpdateUserScore(user);
            }
        }

        public void UpdateUserScore(User user)
        {
            var teaserGames = new List<Game>[NumTeasers];
            var regularGames = new List<Game>();
            var scoreDifferences = new Dictionary<Game, decimal>();
            var selectedTeams = new Dictionary<Game, string>();

            // initialize the teaser game lists - calling teaserGames.Initialize() just sets everything to null
            for (int i = 0; i < NumTeasers; i++)
            {
                teaserGames[i] = new List<Game>();
            }

            // reset the users score for the week
            Scores[user] = 0;

            // check if they have any picks for the week; if not, create new empty list to simplify logic later
            if (!Picks.TryGetValue(user, out var picks))
            {
                picks = new Dictionary<Game, Pick>();
            }

            // add games into their appropriate bucket, depending on if it's a teaser or not
            foreach (var game in Games)
            {
                // invalid teaser numbers count as regular picks
                if (picks.TryGetValue(game, out var pick)
                    && pick.Teaser > 0
                    && pick.Teaser <= NumTeasers)
                {
                    teaserGames[pick.Teaser - 1].Add(game);
                    continue;
                }
                else
                {
                    regularGames.Add(game);
                }
            }

            // move any games that were teased with incorrect number of teasers to regular bucket
            for (var i = 0; i < NumTeasers; i++)
            {
                if (teaserGames[i].Count != 3)
                {
                    for (var j = teaserGames[i].Count - 1; j >= 0; j--)
                    {
                        regularGames.Add(teaserGames[i][j]);
                        teaserGames[i].RemoveAt(j);
                    }
                }
            }

            // first calculate all the score differences, rather than copy and pasta teh logic down below twice
            foreach (var game in Games.Where((game) => game.IsGameDone))
            {
                // if the user didn't make a pick for this game, default is the favourite
                if (picks.TryGetValue(game, out var pick)
                       && !string.IsNullOrEmpty(pick.Team))
                {
                    selectedTeams[game] = pick.Team;
                }
                else
                {
                    selectedTeams[game] = game.Favourite ?? string.Empty;
                }

                decimal scoreDifference = game.HomeScore - game.AwayScore;

                // don't forget to include the spread!
                if (game.Favourite.Equals(game.HomeTeam, StringComparison.OrdinalIgnoreCase))
                {
                    scoreDifference -= game.Spread;
                }
                else
                {
                    scoreDifference += game.Spread;
                }

                scoreDifferences[game] = scoreDifference;
            }

            // count correct picks for all regular games
            foreach (var game in regularGames.Where((game) => game.IsGameDone))
            {
                if (selectedTeams[game].Equals(game.HomeTeam, StringComparison.OrdinalIgnoreCase))
                {
                    if (scoreDifferences[game] > 0)
                    {
                        Scores[user]++;
                    }
                }
                else if (selectedTeams[game].Equals(game.AwayTeam, StringComparison.OrdinalIgnoreCase))
                {
                    if (scoreDifferences[game] < 0)
                    {
                        Scores[user]++;
                    }
                }
            }

            // add 6 points for each set of teasers that has all (ie 3) correct picks
            foreach (var teaserGameList in teaserGames)
            {
                var correctPicks = 0;
                foreach (var game in teaserGameList.Where((game) => game.IsGameDone))
                {
                    if (selectedTeams[game].Equals(game.HomeTeam, StringComparison.OrdinalIgnoreCase))
                    {
                        scoreDifferences[game] += game.Spread;
                    }
                    else
                    {
                        scoreDifferences[game] -= game.Spread;
                    }

                    if (selectedTeams[game].Equals(game.HomeTeam, StringComparison.OrdinalIgnoreCase))
                    {
                        if (scoreDifferences[game] > 0)
                        {
                            correctPicks++;
                        }
                    }
                    else if (selectedTeams[game].Equals(game.AwayTeam, StringComparison.OrdinalIgnoreCase))
                    {
                        if (scoreDifferences[game] < 0)
                        {
                            correctPicks++;
                        }
                    }
                }

                if (correctPicks == 3)
                {
                    Scores[user] += 6;
                }
            }
        }
    }
}
