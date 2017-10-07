using System;

namespace Simia.Entities
{
    [Serializable()]
    public class Game
    {
        public uint Id { get; set; }
        public DateTime GameTime { get; set; }
        public string HomeTeam { get; set; }
        public int HomeScore { get; set; }
        public string AwayTeam { get; set; }
        public int AwayScore { get; set; }
        public string Favourite { get; set; }
        public decimal Spread { get; set; }
        public bool IsGameDone { get; set; }

        public decimal GetScoreDifference()
        {
            decimal result = HomeScore - AwayScore;
            if (!string.IsNullOrWhiteSpace(Favourite))
            {
                if (Favourite.Equals(HomeTeam, StringComparison.OrdinalIgnoreCase))
                {
                    result -= Spread;
                }
                else if (Favourite.Equals(AwayTeam, StringComparison.OrdinalIgnoreCase))
                {
                    result += Spread;
                }
            }

            return result;
        }
    }
}
