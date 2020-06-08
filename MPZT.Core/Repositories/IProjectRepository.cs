using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    /// <summary>
    /// Interface for operations on instances of Project class.
    /// </summary>
    public interface IProjectRepository : IDataRepository<Project>
    {
        /// <summary>
        /// Gets instance of Project class.
        /// </summary>
        /// <param name="areaId">Id of the instance of AreaMPZT class.</param>
        /// <returns>Instance of Project class by specific instance of AreaMPZT class.</returns>
        Project GetByArea(int areaId);
    }
}
