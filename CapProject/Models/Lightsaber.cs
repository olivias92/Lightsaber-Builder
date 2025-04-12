using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CapProject.Models {
    public class Lightsaber {

        // Primary Key
        public int lightsaber_id { get; set; }

        [Required(ErrorMessage = "Please enter a valid name.")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a color.")]
        public string blade_color { get; set; } = string.Empty;

        public int Emitter {  get; set; }
        
        public int Switch {  get; set; }

        public int Hilt { get; set; }

        public int Pommel { get; set; }

        [ValidateNever]
        public ICollection<LightsaberComponent> LightsaberComponents { get; set; }/* = new List<LightsaberComponent>();*/

        public string? Slug => name?.Replace(' ', '-').ToLower();


    } // End class
} // End namespace
