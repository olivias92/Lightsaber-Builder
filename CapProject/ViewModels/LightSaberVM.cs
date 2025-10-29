using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CapProject.ViewModels {
    public class LightSaberVM {

        public int idGiven {  get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string nameSelected {  get; set; } = string.Empty;


        [Required(ErrorMessage = "Emitter is required.")]
        public int emitterSelected { get; set; }


        [Required(ErrorMessage = "Switch is required.")]
        public int switchSelected { get; set; }


        [Required(ErrorMessage = "Hilt is required.")]
        public int hiltSelected { get; set; }


        [Required(ErrorMessage = "Pommel is required.")]
        public int pommelSelected { get; set; }


        [Required(ErrorMessage = "Color is required.")]
        public string colorSelected { get; set; }



        public Dictionary<string, string> emitterPath { get; set; }
        public Dictionary<string, string> switchPath { get; set; }
        public Dictionary<string, string> hiltPath { get; set; }
        public Dictionary<string, string> pommelPath { get; set; }

        public List<SelectListItem> emitterOptions { get; set; }
        public List<SelectListItem> switchOptions { get; set; }
        public List<SelectListItem> hiltOptions { get; set; }
        public List<SelectListItem> pommelOptions { get; set; }
        public List<SelectListItem> colorOptions { get; set; }

        //public static implicit operator LightSaberVM(LightSaberVM v) {
        //    throw new NotImplementedException();
        //}
    } // End class
} // End namespace
