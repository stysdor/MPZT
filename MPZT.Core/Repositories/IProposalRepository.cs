using MPZT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Core.Repositories
{
    public interface IProposalRepository : IDataRepository<Proposal>
    {
        IList<Proposal> GetProposals(int id);

        bool AddLikes(int id);

        bool AddDislikes(int id);
    }
}
