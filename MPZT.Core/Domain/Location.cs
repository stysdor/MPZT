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

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Location p = (Location)obj;

                //Wojewodztwo, Powiat i Gmina nie mogą być puste
                bool isEqual = (Wojewodztwo == p.Wojewodztwo) && (Powiat == p.Powiat) && (Gmina == p.Gmina);
                if (isEqual)
                {
                    isEqual = compareStringProperty(City,p.City) && compareStringProperty(Dzielnica, p.Dzielnica) && compareStringProperty(Street, p.Street) && compareStringProperty(NrLand,p.NrLand);
                }
                return isEqual ;
            }
        }

        private bool compareStringProperty(string prop1, string prop2)
        {
            return prop1 == prop2 || (string.IsNullOrEmpty(prop1) && string.IsNullOrEmpty(prop2));
        }
    }
}
