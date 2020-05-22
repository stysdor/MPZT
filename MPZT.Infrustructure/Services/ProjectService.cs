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
    public class ProjectService: IProjectService
    {
        private IProjectRepository _projectRepository;
        private ICommentRepository _commentRepository;
        private IProjectFileRepository _filesRepository;
        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper)
        {
            _projectRepository = new ProjectRepository();
            _commentRepository = new CommentRepository();
            _filesRepository = new ProjectFileRepository();
            _mapper = mapper;
        }

        public ProjectDto GetProject(int areaId)
        {
            var project = _projectRepository.GetByArea(areaId);
            var files = _filesRepository.GetProjectFiles(project.Id);
            project.Files = files;
            return _mapper.Map<ProjectDto>(project);
        }

        public int AddComment(CommentDto comment)
        {
            var data = _mapper.Map<Comment>(comment);
            return _commentRepository.InsertOrUpdate(data);
        }

        public IList<CommentDto> GetComments(int projectId)
        {
            var comments = _commentRepository.GetComments(projectId);
            return _mapper.Map<IList<CommentDto>>(comments);
        }
    }
}
