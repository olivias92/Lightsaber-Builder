using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CapProject.Models {
    public class Component {


        // Primary Key

        public int component_id { get; set; }

        public string component_type { get; set; } = string.Empty;
        
        public string component_name { get; set; } = string.Empty;

        public string filepath { get; set; } = string.Empty;

        [ValidateNever]
        public ICollection<LightsaberComponent> LightsaberComponents { get; set; }


        // Foreign Key
        //public Lightsaber Lightsaber { get; set; }
        //public int? lightsaber_id { get; set; }

        //public ICollection<ComponentCustom> ComponentCustoms { get; set; }


    } // End class
} // End namespace
