using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHealth.Models
{
    public class Entry
    {
        public int ID { get; set; }
        public DateTime EntrytDate { get; set; }
        public string String { get; set; }

        public virtual User user { get; set; }
    }
}