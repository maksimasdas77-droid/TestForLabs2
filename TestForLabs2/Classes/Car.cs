using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestForLabs2.Classes
{
    internal class Car
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Owner { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public List<Fault> Faults { get; set; }
    }
}
