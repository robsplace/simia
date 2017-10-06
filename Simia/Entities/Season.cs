using System;
using System.ComponentModel;

namespace Simia.Entities
{
    [Serializable()]
    public class Season
    {
        public int Year { get; set; }
        public BindingList<User> Players { get; set; } = new BindingList<User>();
        public Week[] Weeks { get; set; } = new Week[17];

        public void UpdateScores()
        {
            foreach(var week in Weeks)
            {
                week.UpdateScores(Players);
            }
        }
    }
}
