using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHealth.Models
{
    public class ScoreCard
    {
        public int ID { get; set; }
        public DateTime ScoretDate { get; set; }
        public int DayScore { get; set; }
        public int WeekScore { get; set; }
        public int TotalScore { get; set; }


        public virtual User user { get; set; }
    }
}