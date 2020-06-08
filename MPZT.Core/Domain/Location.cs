using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents Location table from datebase.
    /// </summary>
    public class Location: EntityBase
    {
        public string Country { get; set; }
        public string Wojewodztwo { get; set; }
        public string Powiat { get; set; }
        public string Gmina { get; set; }
        public string City { get; set; }
        public string Dzielnica { get; set; }
        public string Street { get; set; }
        public string NrLand { get; set; }
    }
}
