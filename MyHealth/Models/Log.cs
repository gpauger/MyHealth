using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHealth.Models
{
    public class Log
    {
        public int ID { get; set; }
        public DateTime LogtDate { get; set; }
        public double Bedtime { get; set; }
        public double Alcohol { get; set; }
        public double Exercise { get; set; }
        public double Veggies { get; set; }
        public double Meditation { get; set; }
        public double Read { get; set; }

        public virtual User user { get; set; }
    }
}