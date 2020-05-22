using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Treść komentarza")]
        [StringLength(int.MaxValue, MinimumLength = 7, ErrorMessage ="Nieprawidłowa długość komentarza")]
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }
        public string UserName { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}