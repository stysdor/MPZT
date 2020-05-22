using AutoMapper;
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
    public class AreaController : Controller
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

        [HttpGet]
        public ActionResult AddArea()
        {
            AreaModel model = new AreaModel
            {
                GeoPoints = new List<GeoPointModel>()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddArea(AreaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else
            {
                model.OfficeId = 1;
                var data = new ApiClient().PostData<AreaDto>("api/area/Post", _mapper.Map<AreaDto>(model));
                if (data)
                    return RedirectToAction("Index", "Area");
                else
                    return View(model); 
           }
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
            var location = _mapper.Map<LocationDto>(model);
            var data = new ApiClient().PostData<LocationDto, List<AreaDto>>("api/area/PostByLocation", location);
            var list = new List<AreaModel>();
            foreach (AreaDto area in data)
            {
                list.Add(_mapper.Map<AreaModel>(area));
            }
            return View("Index", list);
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