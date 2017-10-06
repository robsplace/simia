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
        public bool IsGameDone { get;
            set; }
    }
}
