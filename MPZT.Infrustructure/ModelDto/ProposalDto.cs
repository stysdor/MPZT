using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.ModelDto
{
    public class ProposalDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public int AreaId { get; set; }
        public int UserId { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
