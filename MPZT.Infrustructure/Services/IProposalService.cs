using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Services
{
    public interface IProposalService
    {
        IList<ProposalDto> GetProposals(int id);

        bool AddLikes(int id);
        bool AddDislikes(int id);
        int AddProposal(ProposalDto proposal);
    }
}
