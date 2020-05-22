using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    public class Location: EntityBase
    {
        public virtual string Country { get; set; }
        public virtual string Wojewodztwo { get; set; }
        public virtual string Powiat { get; set; }
        public virtual string Gmina { get; set; }
        public virtual string City { get; set; }
        public virtual string Dzielnica { get; set; }
        public virtual string Street { get; set; }
        public virtual string NrLand { get; set; }
    }
}
