using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHealth.ViewModels
{
    public class ScoresViewModel
    {
        public int BestScore { get; set; }
        public int AverageScore { get; set; }
        public int TotalScore { get; set; }
        public int WeeklyAverage { get; set; }
        public int WeeklyBest { get; set; }
    }
}