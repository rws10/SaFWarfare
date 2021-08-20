using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaFWarfare.Models
{
    public class Experience
    {
        public int expID { get; set; }
        public string expName { get; set; }
        public int expAttack { get; set; }
        public int expPower { get; set; }
        public int expDefense { get; set; }
        public int expToughness { get; set; }
        public int expMorale { get; set; }
    }
}
