using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    /// <summary>
    /// Interface for operations on instances of ProjectFile class.
    /// </summary>
    public interface IProjectFileRepository
    {
        /// <summary>
        /// Gets IList of instances of ProjectFile class.
        /// </summary>
        /// <param name="projectId">Id of the instance of Project class.</param>
        /// <returns>IList of instances of ProjectFile for the specific instance of Project.</returns>
        IList<ProjectFile> GetProjectFiles(int projectId);
    }
}
