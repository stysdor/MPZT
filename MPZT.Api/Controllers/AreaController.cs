﻿using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MPZT.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AreaController: ApiController
    {
        private IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        //[Route("api/area/Post")]
        //[HttpPost]
        //public IHttpActionResult Post([FromBody] AreaDto area)
        //{
        //    _areaService.InsertOrUpdate(area);
        //    return Json(true);
        //}

        [HttpGet]
        public IHttpActionResult Get()
        {
            var list = _areaService.GetAll();
            return Json(list);
        }


        [Route("api/area/PostByLocation")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult PostByLocation([FromBody] LocationDto location)
        {
            return Json(_areaService.GetByLocation(location));
        }

        [Route("api/area/PostByGeoPoint")]
        [HttpPost]
        public IHttpActionResult PostByGeoPoint([FromBody] GeoPointSearchDto point)
        {
            return Json(_areaService.GetByGeoPoint(point));
        }

        
    }
}