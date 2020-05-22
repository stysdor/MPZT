using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.ModelDto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }

        public IList<ProjectFileDto> Files { get; set; }
    }
}
