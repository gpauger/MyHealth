using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHealth.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Measurements> Measurements { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<Entry> Entry { get; set; }
    }
}