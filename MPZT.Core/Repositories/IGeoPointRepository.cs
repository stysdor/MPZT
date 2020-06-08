using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    /// <summary>
    /// Interface for operations on instances of GeoPoint class.
    /// </summary>
    public interface IGeoPointRepository: IDataRepository<GeoPoint>
    {
        /// <summary>
        /// Gets List of instances of GeoPoint class.
        /// </summary>
        /// <param name="point">Instance of GeoPoint class - the centre of area.</param>
        /// <param name="range">Range in km around <paramref name="point"/></param>
        /// <returns>List of instances of GeoPoint class in specific area.</returns>
        List<GeoPoint> GetAllInRange(GeoPoint point, int range);

        /// <summary>
        /// Gets List of instances of GeoPoint class.
        /// </summary>
        /// <param name="areaId">Id of instance of AreaMPZT class.</param>
        /// <returns>List of instances of GeoPoint class in specific instance of AreaMPZT class..</returns>
        List<GeoPoint> GetByArea(int areaId);
    }
}
