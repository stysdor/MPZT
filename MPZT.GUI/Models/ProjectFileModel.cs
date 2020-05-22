using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class ProjectFileModel
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string NameFile { get; set; }
    }
}