using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class GeoPointSearchModel
    {
        public GeoPointModel GeoPoint { get; set; }

        [Display(Name = "Zakres poszukiwań w km")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Range(0, 1000, ErrorMessage = "Wartość w przedziale 0-1000")]
        public int Range { get; set; }
    }
}