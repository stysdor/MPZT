using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class AreaProjectModel
    {
        public ProjectModel Project { get; set; }
        public AreaModel Area { get; set; }

        [Display(Name = "Komentarze")]
        public List<CommentModel> Comments { get; set; }
    }
}