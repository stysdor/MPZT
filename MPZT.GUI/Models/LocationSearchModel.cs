using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class LocationSearchModel
    {
        public LocationSearchModel()
        {
            Wojewodztwa = new List<string>()
                {
                    "dolnośląskie",
                    "kujawsko-pomorskie",
                    "lubelskie",
                    "lubuskie",
                   "łódzkie",
                    "małopolskie",
                    "mazowieckie",
                    "opolskie",
                    "podkarpackie",
                    "podlaskie",
                    "pomorskie",
                    "śląskie",
                    "świętokrzyskie",
                    "warmińsko-mazurskie",
                    "wielkopolskie",
                    "zachodniopomorskie"
                };
        }

        [Display(Name = "Kraj")]
        public string Country { get; set; }
        public string Wojewodztwo { get; set; }
        public string Powiat { get; set; }
        public string Gmina { get; set; }
        [Display(Name = "Miasto")]
        public string City { get; set; }

        public string Dzielnica { get; set; }
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "Nr działki")]
        public string NrLand { get; set; }

        public List<string> Wojewodztwa { get; set; }
    }
}