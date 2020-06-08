using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    /// <summary>
    /// Interface for operations on instances of Location class.
    /// </summary>
    public interface ILocationRepository: IDataRepository<Location>
    {
        /// <summary>
        /// Gets List of instances of Location class.
        /// </summary>
        /// <param name="location">Instance of Location class with some property.</param>
        /// <returns>List of instances of Location witch contain the same value of one of the properties like <paramref name="location"/></returns>
        List<Location> GetByLocation(Location location);
    }
}
