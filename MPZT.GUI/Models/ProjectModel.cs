using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required]
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Numer projektu")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Opis projektu")]
        [StringLength(int.MaxValue, MinimumLength = 7)]
        public string Description { get; set; }

        [Display(Name = "Załączniki")]
        public IList<ProjectFileModel> Files { get; set; }
    }
}