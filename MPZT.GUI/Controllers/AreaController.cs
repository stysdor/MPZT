using AutoMapper;
using MPZT.GUI.CustomAuthentication;
using MPZT.GUI.Logic;
using MPZT.GUI.Models;
using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPZT.GUI.Controllers
{
    public class AreaController : BaseController
    {
        private readonly IMapper _mapper;
        public AreaController(IMapper mapper)
        {
            _mapper = mapper;
        }


        #region adding new area

        public PartialViewResult GeoPoint()
        {
            return PartialView("_GeoPoint", new GeoPointModel());
        }

        public PartialViewResult Location()
        {
            return PartialView("_LocationForm", new LocationModel());
        }

        [CustomAuthorize(Roles = "OfficeMember")]
        [HttpGet]
        public ActionResult AddArea()
        {
            AreaModel model = new AreaModel();
            return View(model);
        }

        [CustomAuthorize(Roles = "OfficeMember")]
        [HttpPost]
        public ActionResult AddArea(AreaModel model)
        {
            model.PhaseId = (int)model.PhasePhase;
            if (ModelState.IsValid)
            {
                foreach (var point in model.GeoPoints)
                {
                    if (!TryValidateModel(point))
                        return View(model);      
                }
                model.OfficeId = new UserApi().GetOfficeIdByUserId(User.UserId);
                if (model.OfficeId > 0)
                {
                    var data = new ApiClient().PostData<AreaDto>("api/area/Post", _mapper.Map<AreaDto>(model));
                    if (data)
                        return RedirectToAction("Index", "Area");
                }      
            }
            return View(model);
        }

        #endregion

        #region getting list of areas

        public ActionResult Index()
        {
            var data = new ApiClient().GetData<List<AreaDto>>("api/area");
            var list = new List<AreaModel>();
            foreach (AreaDto area in data)
            {
                list.Add(_mapper.Map<AreaModel>(area));
            }
            return View(list);
        }

        public ActionResult PostByLocation(LocationModel model)
        {
            if (ModelState.IsValid)
            {
                var location = _mapper.Map<LocationDto>(model);
                var data = new ApiClient().PostData<LocationDto, List<AreaDto>>("api/area/PostByLocation", location);
                var list = new List<AreaModel>();
                if (!(data == null))
                {
                    foreach (AreaDto area in data)
                    {
                        list.Add(_mapper.Map<AreaModel>(area));
                    }
                }
                return View("Index", list);
            }
            else return View("Index", "Home", model);
        }

        public ActionResult PostByGeoPoint(GeoPointSearchModel model)
        { 
            var pointSearch = _mapper.Map<GeoPointSearchDto>(model);
            var data = new ApiClient().PostData<GeoPointSearchDto, List<AreaDto>>("api/area/PostByGeoPoint/", pointSearch);
            var list = new List<AreaModel>();
            foreach (AreaDto area in data)
            {
                list.Add(_mapper.Map<AreaModel>(area));
            }
            return View("Index",list);
        }

        #endregion

        #region seeing details of area

        public ActionResult ViewDetails(AreaModel item)
        {
            if(item.PhaseId == 1)
                return RedirectToAction("GetProposals", "Concept", item);
            if (item.PhaseId == 2)
                return RedirectToAction("GetProject", "Project", item);
            else return View();
        }

        #endregion
    }
}