using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MPZT.Api.Controllers
{
    public class ConceptController : ApiController
    {
        private IProposalService _proposalService;

        public ConceptController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }

        [Route("api/concept/GetProposals/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetProposals(int id)
        {
            return Json(_proposalService.GetProposals(id));
        }

        [Route("api/concept/AddLikes/{id:int}")]
        [HttpGet]
        public IHttpActionResult AddLikes(int id)
        {
            return Json(_proposalService.AddLikes(id));
        }

        [Route("api/concept/AddDislikes/{id:int}")]
        [HttpGet]
        public IHttpActionResult AddDislikes(int id)
        {
            return Json(_proposalService.AddDislikes(id));
        }

        [Route("api/concept/PostProposal")]
        [HttpPost]
        public IHttpActionResult PostProposal([FromBody] ProposalDto proposal)
        {
            return Json(_proposalService.AddProposal(proposal));
        }
    }
}