using AutoMapper;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Services
{
    public class ProposalService : IProposalService
    {
        private IProposalRepository _proposalRepository;
        private readonly IMapper _mapper;

        public ProposalService(IMapper mapper)
        {
            _proposalRepository = new ProposalRepository();
            _mapper = mapper;
        }

        public IList<ProposalDto> GetProposals(int id)
        {
            var proposals = _proposalRepository.GetProposals(id);
            return _mapper.Map<IList<ProposalDto>>(proposals);
        }

        public bool AddLikes(int id)
        {
            return _proposalRepository.AddLikes(id);
        }

        public bool AddDislikes(int id)
        {
            return _proposalRepository.AddDislikes(id);
        }

        public int AddProposal(ProposalDto proposal)
        {
            var data = _mapper.Map<Proposal>(proposal);
            return _proposalRepository.InsertOrUpdate(data);
        }
    }
}
