using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    /// <summary>
    /// Interface for operations on instances of Comment class.
    /// </summary>
    public interface ICommentRepository: IDataRepository<Comment>
    {
        /// <summary>
        /// Gets instances of Comment class for specific projectId.
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        /// <returns>IList of instances of Comment class with specific projectId.</returns>
        IList<Comment> GetComments(int projectId);
    }
}
