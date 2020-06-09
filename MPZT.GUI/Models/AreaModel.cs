using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MPZT.GUI.Models
{
    public class AreaModel
    {
        public AreaModel()
        {
            GeoPoints = new List<GeoPointModel>();
            Location = new LocationModel(); 
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Termin konsultacji")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm")]
        public DateTime ConsultationTime { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Data zakończenia postępowania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Faza opracowania")]
        public int PhaseId{ get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Faza opracowania")]
        public Phase PhasePhase { get; set; }

        [Display(Name = "Lokalizacja")]
        public LocationModel Location { get; set; }

        [Display(Name = "Współrzędne")]
        public List<GeoPointModel> GeoPoints { get; set; }

        public int OfficeId { get; set; }

        public enum Phase
        {
            Koncepcja = 1,
            Projekt = 2
        }

    }
  


}
