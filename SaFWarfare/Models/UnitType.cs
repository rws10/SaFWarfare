using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaFWarfare.Models
{
    public class UnitType
    {
        public int uniTypID { get; set; }
        public string uniTypName { get; set; }
        public string uniTypDescription { get; set; }
        public int uniTypAttack { get; set; }
        public int uniTypPower { get; set; }
        public int uniTypDefense { get; set; }
        public int uniTypToughness { get; set; }
        public int uniTypMorale { get; set; }
        public float uniTypCostModifier { get; set; }
    }
}
