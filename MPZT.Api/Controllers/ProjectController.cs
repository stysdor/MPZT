using MPZT.Infrustructure.ModelDto;
using MPZT.Infrustructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MPZT.Api.Controllers
{
    public class ProjectController : ApiController
    {

        private IProjectService _projectService;

        public ProjectController(IProjectService proposalService)
        {
            _projectService = proposalService;
        }

        [Route("api/project/GetProject/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetProject(int id)
        {
            return Json(_projectService.GetProject(id));
        }

        [Route("api/project/PostComment")]
        [HttpPost]
        public IHttpActionResult PostComment([FromBody] CommentDto comment)
        {
            return Json(_projectService.AddComment(comment));
        }

        [Route("api/project/GetComments/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetComments(int id)
        {
            return Json(_projectService.GetComments(id));
        }
    }
}
