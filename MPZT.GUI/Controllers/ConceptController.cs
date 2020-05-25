using AutoMapper;
using MPZT.GUI.CustomAuthentication;
using MPZT.GUI.DataAccess;
using MPZT.GUI.Logic;
using MPZT.GUI.Models;
using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MPZT.GUI.Controllers
{
    public class ConceptController : Controller
    {
        private readonly IMapper _mapper;
        public ConceptController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: Proposal
        public ActionResult GetProposals(AreaModel item)
        {
            var data = new ApiClient().GetData<List<ProposalDto>>($"api/concept/GetProposals/{item.Id}");
            var list = new List<ProposalModel>();
            foreach (ProposalDto proposal in data)
            {
                list.Add(_mapper.Map<ProposalModel>(proposal));
            }

            AreaProposalsModel model = new AreaProposalsModel()
            {
                Area = item,
                Proposals = list
            };

            return View("Index",model);
        }

        [CustomAuthorize(Roles = "User")]
        public ActionResult AddLikes(ProposalModel item)
        {
            AreaProposalsModel model = (AreaProposalsModel)TempData["model"];
            var isSuccess = new ApiClient().GetData<bool>($"api/concept/AddLikes/{item.Id}");
            if (isSuccess)
            {
                int i = model.Proposals.FindIndex(x => x.Id == item.Id);
                model.Proposals[i].Likes++;
            }
            return View("Index", model);
        }

        [CustomAuthorize(Roles = "User")]
        public ActionResult AddDislikes(ProposalModel item)
        {
            AreaProposalsModel model = (AreaProposalsModel)TempData["model"];
            var isSuccess = new ApiClient().GetData<bool>($"api/concept/AddDislikes/{item.Id}");
            if (isSuccess)
            {
                int i = model.Proposals.FindIndex(x => x.Id == item.Id);
                model.Proposals[i].Dislikes++;
            }
            return View("Index", model);
        }

        [CustomAuthorize(Roles = "User")]
        [HttpGet]
        public ActionResult AddProposal()
        {
            AreaProposalsModel data = (AreaProposalsModel)TempData["model"];

            ProposalModel model = new ProposalModel()
            {
                AreaId = data.Area.Id,
                UserId = 1
            };
            return View(model);
        }

        [CustomAuthorize(Roles = "User")]
        [HttpPost]
        public ActionResult AddProposal(ProposalModel model)
        {
            if (ModelState.IsValid) {
                ProposalDto modelDto = _mapper.Map<ProposalDto>(model);
                var data = new ApiClient().PostData($"api/concept/PostProposal", modelDto);
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
    }
}