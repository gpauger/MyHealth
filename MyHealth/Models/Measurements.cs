using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHealth.Models
{
    public class Measurements
    {
        public int ID { get; set; }
        public DateTime MeasurementDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Belly { get; set; }
        public double Waist { get; set; }
        public double Thigh { get; set; }
        public double Bicep { get; set; }

        public virtual User user { get; set; }




    }
}