using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForLabs2.Classes
{
    [Serializable]
    internal class Fault
    {
        public string Description { get; set; }
        public DateTime Date {  get; set; }
    }
}
