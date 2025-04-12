namespace CapProject.Models {
    public class LightsaberComponent {

        public int lightsaber_id {  get; set; }
        public Lightsaber Lightsaber { get; set; } = null!;

        public int component_id { get; set; }
        public Component Component { get; set; } = null!;

        //public ICollection<ComponentCustom> ComponentCustoms { get; set; }
        //public int cust_id { get; set; }
        //public ComponentCustom ComponentCustoms { get; set; }


    } // End class
} // End namespace
