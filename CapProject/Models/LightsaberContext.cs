using Microsoft.EntityFrameworkCore;

namespace CapProject.Models {
    public class LightsaberContext : DbContext {

        public LightsaberContext(DbContextOptions<LightsaberContext> options)   
            : base(options) 
            { }

        public DbSet<Lightsaber> Lightsabers { get; set; } = null!;
        public DbSet<Component> Components { get; set; } = null!;
        //public DbSet<ComponentCustom> ComponentsCustoms { get; set; } = null!;
        public DbSet<LightsaberComponent> LightsaberComponent { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder) {



            modelBuilder.Entity<LightsaberComponent>()
                .HasKey(lc => new { lc.lightsaber_id, lc.component_id });


            modelBuilder.Entity<LightsaberComponent>()
                .HasOne(lc => lc.Lightsaber)
                .WithMany(l => l.LightsaberComponents)
                .HasForeignKey(lc => lc.lightsaber_id);



            modelBuilder.Entity<LightsaberComponent>()
                .HasOne(lc => lc.Component)
                .WithMany(c => c.LightsaberComponents)
                .HasForeignKey(lc => lc.component_id);

            modelBuilder.Entity<Component>()
                .HasKey(c => c.component_id);

            modelBuilder.Entity<Lightsaber>()
             .HasKey(l => l.lightsaber_id);


            modelBuilder.Entity<Lightsaber>().HasData(

                new Lightsaber { lightsaber_id = 1, name = "Example", blade_color ="Blue",
                    Emitter = 3,
                    Switch = 1,
                    Hilt = 7,
                    Pommel = 5
                    }

                );

            //modelBuilder.Entity<LightsaberComponent>().HasData(
            //        new LightsaberComponent { lightsaber_id = 1, component_id = 1}

            //    );
            modelBuilder.Entity<Component>().HasData(
                // Elemental Nature Designs
                    new Component { component_id = 1, component_name = "Elemental Nature I", component_type = "Switch", filepath = "/ModelsLS/Elemental Nature/CE3E3V2_EN_Switch_1.stl" }, 
                    new Component { component_id = 2, component_name = "Elemental Nature II", component_type = "Switch", filepath = "/ModelsLSElemental Nature/CE3E3V2_EN_Switch_2.stl" }, 
                    new Component { component_id = 3, component_name = "Elemental Nature I", component_type = "Emitter", filepath = "/ModelsLS/Elemental Nature/EN_Emitter_1.stl" },
                    new Component { component_id = 4, component_name = "Elemental Nature II", component_type = "Emitter", filepath = "/ModelsLS/Elemental Nature/EN_Emitter_2.stl" },
                    new Component { component_id = 5, component_name = "Elemental Nature I", component_type = "Pommel", filepath = "/ModelsLS/Elemental Nature/EN_EndCap_1.stl" }, 
                    new Component { component_id = 6, component_name = "Elemental Nature II", component_type = "Pommel", filepath = "/ModelsLS/Elemental Nature/EN_EndCap_2.stl" },
                    new Component { component_id = 7, component_name = "Elemental Nature I", component_type = "Hilt", filepath = "/ModelsLS/Elemental Nature/EN_Sleeve_1.stl" },
                    new Component { component_id = 8, component_name = "Elemental Nature II", component_type = "Hilt", filepath = "/ModelsLS/Elemental Nature/EN_Sleeve_2.stl" }, 
                    new Component { component_id = 9, component_name = "Elemental Nature III", component_type = "Hilt", filepath = "/ModelsLS/Elemental Nature/EN_Sleeve_3.stl" },
                    new Component { component_id = 10, component_name = "Elemental Nature IV", component_type = "Hilt", filepath = "/ModelsLS/Elemental Nature/EN_Sleeve_4.stl" },


                    // Peace and Justice Designs
                    new Component { component_id = 11, component_name = "Peace and Justice I", component_type = "Switch", filepath = "/ModelsLS/Peace and Justice/CE3E3V2_PJ_Switch_1.stl" },
                    new Component { component_id = 12, component_name = "Peace and Justice II", component_type = "Switch", filepath = "/ModelsLS/Peace and Justice/CE3E3V2_PJ_Switch_2.stl" },
                    new Component { component_id = 13, component_name = "Peace and Justice I", component_type = "Emitter", filepath = "/ModelsLS/Peace and Justice/PJ_Emitter_1.stl" },
                    new Component { component_id = 14, component_name = "Peace and Justice II", component_type = "Emitter", filepath = "/ModelsLS/Peace and Justice/PJ_Emitter_2.stl" },
                    new Component { component_id = 15, component_name = "Peace and Justice I", component_type = "Pommel", filepath = "/ModelsLS/Peace and Justice/PJ_EndCap_1.stl" },
                    new Component { component_id = 16, component_name = "Peace and Justice II", component_type = "Pommel", filepath = "/ModelsLS/Peace and Justice/PJ_EndCap_2.stl" },
                    new Component { component_id = 17, component_name = "Peace and Justice I", component_type = "Hilt", filepath = "/ModelsLS/Peace and Justice/PJ_Sleeve_1.stl" },
                    new Component { component_id = 18, component_name = "Peace and Justice II", component_type = "Hilt", filepath = "/ModelsLS/Peace and Justice/PJ_Sleeve_2.stl" },
                    new Component { component_id = 19, component_name = "Peace and Justice III", component_type = "Hilt", filepath = "/ModelsLS/Peace and Justice/PJ_Sleeve_3.stl" },
                    new Component { component_id = 20, component_name = "Peace and Justice IV", component_type = "Hilt", filepath = "/ModelsLS/Peace and Justice/PJ_Sleeve_4.stl" },

                    // Power and Control Designs
                    new Component { component_id = 21, component_name = "Power and Control I", component_type = "Switch", filepath = "/ModelsLS/Power and Control/CE3E3V2_PC_Switch_1.stl" },
                    new Component { component_id = 22, component_name = "Power and Control II", component_type = "Switch", filepath = "/ModelsLS/Power and Control/CE3E3V2_PC_Switch_1.stl" },
                    new Component { component_id = 23, component_name = "Power and Control I", component_type = "Emitter", filepath = "/ModelsLS/Power and Control/PC_Emitter_1.stl" },
                    new Component { component_id = 24, component_name = "Power and Control II", component_type = "Emitter", filepath = "/ModelsLS/Power and Control/PC_Emitter_2.stl" },
                    new Component { component_id = 25, component_name = "Power and Control I", component_type = "Pommel", filepath = "/ModelsLS/Power and Control/PC_End_Cap_1.stl" },
                    new Component { component_id = 26, component_name = "Power and Control II", component_type = "Pommel", filepath = "/ModelsLS/Power and Control/PC_End_Cap_2.stl" },
                    new Component { component_id = 27, component_name = "Power and Control I", component_type = "Hilt", filepath = "/ModelsLS/Power and Control/PC_Sleeve_1.stl" },
                    new Component { component_id = 28, component_name = "Power and Control II", component_type = "Hilt", filepath = "/ModelsLS/Power and Control/PC_Sleeve_2.stl" },
                    new Component { component_id = 29, component_name = "Power and Control III", component_type = "Hilt", filepath = "/ModelsLS/Power and Control/PC_Sleeve_3.stl" },
                    new Component { component_id = 30, component_name = "Power and Control IV", component_type = "Hilt", filepath = "/ModelsLS/Power and Control/PC_Sleeve_4.stl" },

                     // Protection and Defense Designs
                    new Component { component_id = 31, component_name = "Protection and Defense I", component_type = "Switch", filepath = "/ModelsLS/Protection and Defense/CE3E3V2_PD_Switch_1.stl" },
                    new Component { component_id = 32, component_name = "Protection and Defense II", component_type = "Switch", filepath = "/ModelsLS/Protection and Defense/CE3E3V2_PD_Switch_1.stl" },
                    new Component { component_id = 33, component_name = "Protection and Defense I", component_type = "Emitter", filepath = "/ModelsLS/Protection and Defense/PD_Emitter_1.stl" },
                    new Component { component_id = 34, component_name = "Protection and Defense II", component_type = "Emitter", filepath = "/ModelsLS/Protection and Defense/PD_Emitter_2.stl" },
                    new Component { component_id = 35, component_name = "Protection and Defense I", component_type = "Pommel", filepath = "/ModelsLS/Protection and Defense/PD_EndCap_1.stl" },
                    new Component { component_id = 36, component_name = "Protection and Defense II", component_type = "Pommel", filepath = "/ModelsLS/Protection and Defense/PD_EndCap_2.stl" },
                    new Component { component_id = 37, component_name = "Protection and Defense I", component_type = "Hilt", filepath = "/ModelsLS/Protection and Defense/PD_Sleeve_1.stl" },
                    new Component { component_id = 38, component_name = "Protection and Defense II", component_type = "Hilt", filepath = "/ModelsLS/Protection and Defense/PD_Sleeve_2.stl" },
                    new Component { component_id = 39, component_name = "Protection and Defense III", component_type = "Hilt", filepath = "/ModelsLS/Protection and Defense/PD_Sleeve_3.stl" },
                    new Component { component_id = 40, component_name = "Protection and Defense IV", component_type = "Hilt", filepath = "/ModelsLS/Protection and Defense/PD_Sleeve_4.stl" }

                );
            
        } // End protected


        



    } // End class
} // End namespace
