using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Domain
{
    /// <summary>
    /// Represents ProjectFile table from datebase.
    /// </summary>
    public class Proposal: EntityBase
    {
        public string Description { get; set; }
        public User User { get; set; }
        public AreaMPZT AreaMPZT { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        /// <summary>
        /// Gets the value of property by its <paramref name="name"/>
        /// </summary>
        /// <param name="name">The name of the value to get.</param>
        /// <returns>The property with specified name</returns>
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
