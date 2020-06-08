using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    /// <summary>
    /// Interface for operations on instances of Proposal class.
    /// </summary>
    public interface IProposalRepository : IDataRepository<Proposal>
    {
        /// <summary>
        /// Gets IList of instances of Proposal class.
        /// </summary>
        /// <param name="id">Id of the instance of AreaMPZT class.</param>
        /// <returns>IList of instances of Proposal class for the specific <paramref name="id"/> of instance of AreaMPZT class.</returns>
        IList<Proposal> GetProposals(int id);

        /// <summary>
        /// Increases value of Like property of instance of Proposal class.
        /// </summary>
        /// <param name="id">Id of the specific instance of Proposal class.</param>
        /// <returns>True if increase succeeds, or false otherwise.</returns>
        bool AddLikes(int id);

        /// <summary>
        /// Increases value of Dislike property of instance of Proposal class.
        /// </summary>
        /// <param name="id">Id of the specific instance of Proposal class.</param>
        /// <returns>True if increase succeeds, or false otherwise.</returns>
        bool AddDislikes(int id);
    }
}
