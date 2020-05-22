using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class ProposalModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Opis propozycji")]
        public string Description { get; set; }

        [Display(Name = "Autor")]
        public string UserName { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int AreaId { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}