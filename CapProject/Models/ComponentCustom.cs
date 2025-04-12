using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CapProject.Models {
    public class ComponentCustom {

        // Primary Key
        public int cust_id { get; set; }

        public string size { get ; set; } = string.Empty;

        // FK sorta
        public int component_id { get; set; }
        public Component Component { get; set; } = null!;

        // FK for relation to LightsaberComponent
        public int lightsaber_component_id { get; set; }
        public LightsaberComponent LightsaberComponent { get; set; } = null!;

    } // End class
} // End namespace
