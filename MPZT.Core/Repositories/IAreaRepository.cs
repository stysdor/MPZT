using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    /// <summary>
    /// Interface for operations on instances of AreaMPZT class.
    /// </summary>
    public interface IAreaRepository: IDataRepository<AreaMPZT>
    {
        /// <summary>
        /// Gets list of instances of AreaMPZT class by specific location.
        /// </summary>
        /// <param name="locations">List of Locations </param>
        /// <returns>List of AreaMPZT with specific Locations.</returns>
        List<AreaMPZT> GetByLocation(List<Location> locations);

        /// <summary>
        /// Gets list of instances of AreaMPZT class by specific list of instances of GeoPoint class.
        /// </summary>
        /// <param name="points">List of instances of GeoPoint class</param>
        /// <returns>List of AreaMPZT with specific GeoPoints.</returns>
        List<AreaMPZT> GetByGeoPoint(List<GeoPoint> points);
    }
}
