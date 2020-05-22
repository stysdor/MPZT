using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    public class Proposal: EntityBase
    {
        public virtual string Description { get; set; }
        public virtual User User { get; set; }
        public virtual AreaMPZT AreaMPZT { get; set; }
        public virtual int Likes { get; set; }
        public virtual int Dislikes { get; set; }

        public object this[string name]
        {
            get
            {
                var properties = typeof(Proposal)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    if (property.Name == name && property.CanRead)
                        return property.GetValue(this, null);
                }

                throw new ArgumentException("Can't find property");

            }
            set
            {
                return;
            }
        }

    }
}
