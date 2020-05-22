using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class AreaProposalsModel
    {
        public AreaModel Area { get; set; }
        public List<ProposalModel> Proposals {get; set;}
    }
}