using System;

namespace Simia.Entities
{
    [Serializable()]
    public class Pick : ICloneable
    {
        public string Team { get; set; }
        public int Teaser { get; set; } = 0;

        public object Clone()
        {
            return new Pick() { Team = Team, Teaser = Teaser };
        }
    }
}
