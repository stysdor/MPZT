using MPZT.Infrustructure.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Services
{
    public interface IProjectService
    {
        ProjectDto GetProject(int areaId);
        IList<CommentDto> GetComments(int projectId);
        int AddComment(CommentDto comment); 
    }
}
