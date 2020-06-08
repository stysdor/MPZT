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
    public class ProjectController : BaseController
    {
        private IMapper _mapper;
        public ProjectController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProject(AreaModel item)
        {
            var data = new ApiClient().GetData<ProjectDto>($"api/project/GetProject/{item.Id}");
            if (!(data == null))
            {
                var data2 = new ApiClient().GetData<List<CommentDto>>($"api/project/GetComments/{data.Id}");
                List<CommentModel> commentList = new List<CommentModel>();
                if (!(data2 == null))
                {
                    
                    foreach (var comment in data2)
                    {
                        commentList.Add(_mapper.Map<CommentModel>(comment));
                    }
                }
                
                ProjectModel project = _mapper.Map<ProjectModel>(data);
                project.AreaId = item.Id;   
                AreaProjectModel model = new AreaProjectModel
                {
                    Area = item,
                    Project = project,
                    Comments = commentList
                };

                return View("Index", model);
            }
            return View("Index");   
        }

        [CustomAuthorize(Roles = "User")]
        [HttpGet]
        public ActionResult AddComment()
        {
            AreaProjectModel data = (AreaProjectModel)TempData["model"];

            CommentModel model = new CommentModel()
            {
                ProjectId = data.Project.Id,
                UserId = User.UserId
            };
            return View(model);
        }

        [CustomAuthorize(Roles = "User")]
        [HttpPost]
        public ActionResult AddComment(CommentModel model)
        {
            if (ModelState.IsValid)
            {
                CommentDto modelDto = _mapper.Map<CommentDto>(model);
                var data = new ApiClient().PostData($"api/project/PostComment", modelDto);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
         }

    }
}