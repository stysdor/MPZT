using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class GeoPointModel
    {
        public int Id { get; set; }

        [Display(Name = "Szerokość geograficzna N")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Range(0,90,ErrorMessage = "Wartość w przedziale 0-90")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double Latitude { get; set; }

        [Display(Name = "Długość geograficzna E")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Range(0, 180, ErrorMessage = "Wartość w przedziale 0-180")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double Longitude { get; set; }

    }
}