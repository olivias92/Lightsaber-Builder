using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CapProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    component_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    component_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    component_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.component_id);
                });

            migrationBuilder.CreateTable(
                name: "Lightsabers",
                columns: table => new
                {
                    lightsaber_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    blade_color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emitter = table.Column<int>(type: "int", nullable: false),
                    Switch = table.Column<int>(type: "int", nullable: false),
                    Hilt = table.Column<int>(type: "int", nullable: false),
                    Pommel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lightsabers", x => x.lightsaber_id);
                });

            migrationBuilder.CreateTable(
                name: "LightsaberComponent",
                columns: table => new
                {
                    lightsaber_id = table.Column<int>(type: "int", nullable: false),
                    component_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightsaberComponent", x => new { x.lightsaber_id, x.component_id });
                    table.ForeignKey(
                        name: "FK_LightsaberComponent_Components_component_id",
                        column: x => x.component_id,
                        principalTable: "Components",
                        principalColumn: "component_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LightsaberComponent_Lightsabers_lightsaber_id",
                        column: x => x.lightsaber_id,
                        principalTable: "Lightsabers",
                        principalColumn: "lightsaber_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "component_id", "component_name", "component_type", "filepath" },
                values: new object[,]
                {
                    { 1, "Elemental Nature I", "Switch", "~/Lightsabers/Elemental Nature/CE3E3V2_EN_Switch_1.stl" },
                    { 2, "Elemental Nature II", "Switch", "~/Lightsabers/Elemental Nature/CE3E3V2_EN_Switch_2.stl" },
                    { 3, "Elemental Nature I", "Emitter", "~/Lightsabers/Elemental Nature/EN_Emitter_1.stl" },
                    { 4, "Elemental Nature II", "Emitter", "~/Lightsabers/Elemental Nature/EN_Emitter_2.stl" },
                    { 5, "Elemental Nature I", "Pommel", "~/Lightsabers/Elemental Nature/EN_EndCap_1.stl" },
                    { 6, "Elemental Nature II", "Pommel", "~/Lightsabers/Elemental Nature/EN_EndCap_2.stl" },
                    { 7, "Elemental Nature I", "Hilt", "~/Lightsabers/Elemental Nature/EN_Sleeve_1.stl" },
                    { 8, "Elemental Nature II", "Hilt", "~/Lightsabers/Elemental Nature/EN_Sleeve_2.stl" },
                    { 9, "Elemental Nature III", "Hilt", "~/Lightsabers/Elemental Nature/EN_Sleeve_3.stl" },
                    { 10, "Elemental Nature IV", "Hilt", "~/Lightsabers/Elemental Nature/EN_Sleeve_4.stl" },
                    { 11, "Peace and Justice I", "Switch", "~/Lightsabers/Peace and Justice/CE3E3V2_PJ_Switch_1.stl" },
                    { 12, "Peace and Justice II", "Switch", "~/Lightsabers/Peace and Justice/CE3E3V2_PJ_Switch_2.stl" },
                    { 13, "Peace and Justice I", "Emitter", "~/Lightsabers/Peace and Justice/PJ_Emitter_1.stl" },
                    { 14, "Peace and Justice II", "Emitter", "~/Lightsabers/Peace and Justice/PJ_Emitter_2.stl" },
                    { 15, "Peace and Justice I", "Pommel", "~/Lightsabers/Peace and Justice/PJ_EndCap_1.stl" },
                    { 16, "Peace and Justice II", "Pommel", "~/Lightsabers/Peace and Justice/PJ_EndCap_2.stl" },
                    { 17, "Peace and Justice I", "Hilt", "~/Lightsabers/Peace and Justice/PJ_Sleeve_1.stl" },
                    { 18, "Peace and Justice II", "Hilt", "~/Lightsabers/Peace and Justice/PJ_Sleeve_2.stl" },
                    { 19, "Peace and Justice III", "Hilt", "~/Lightsabers/Peace and Justice/PJ_Sleeve_3.stl" },
                    { 20, "Peace and Justice IV", "Hilt", "~/Lightsabers/Peace and Justice/PJ_Sleeve_4.stl" },
                    { 21, "Power and Control I", "Switch", "~/Lightsabers/Power and Control/CE3E3V2_PC_Switch_1.stl" },
                    { 22, "Power and Control II", "Switch", "~/Lightsabers/Power and Control/CE3E3V2_PC_Switch_1.stl" },
                    { 23, "Power and Control I", "Emitter", "~/Lightsabers/Power and Control/PC_Emitter_1.stl" },
                    { 24, "Power and Control II", "Emitter", "~/Lightsabers/Power and Control/PC_Emitter_2.stl" },
                    { 25, "Power and Control I", "Pommel", "~/Lightsabers/Power and Control/PC_EndCap_1.stl" },
                    { 26, "Power and Control II", "Pommel", "~/Lightsabers/Power and Control/PC_EndCap_2.stl" },
                    { 27, "Power and Control I", "Hilt", "~/Lightsabers/Power and ControlPC_Sleeve_1.stl" },
                    { 28, "Power and Control II", "Hilt", "~/Lightsabers/Power and Control/PC_Sleeve_2.stl" },
                    { 29, "Power and Control III", "Hilt", "~/Lightsabers/Power and Control/PC_Sleeve_3.stl" },
                    { 30, "Power and Control IV", "Hilt", "~/Lightsabers/Power and Control/PC_Sleeve_4.stl" },
                    { 31, "Protection and Defense I", "Switch", "~/Lightsabers/Protection and Defense/CE3E3V2_PD_Switch_1.stl" },
                    { 32, "Protection and Defense II", "Switch", "~/Lightsabers/Protection and Defense/CE3E3V2_PD_Switch_1.stl" },
                    { 33, "Protection and Defense I", "Emitter", "~/Lightsabers/Protection and Defense/PD_Emitter_1.stl" },
                    { 34, "Protection and Defense II", "Emitter", "~/Lightsabers/Protection and Defense/PD_Emitter_2.stl" },
                    { 35, "Protection and Defense I", "Pommel", "~/Lightsabers/Protection and Defense/PD_EndCap_1.stl" },
                    { 36, "Protection and Defense II", "Pommel", "~/Lightsabers/Protection and Defense/PD_EndCap_2.stl" },
                    { 37, "Protection and Defense I", "Hilt", "~/Lightsabers/Protection and Defense/PD_Sleeve_1.stl" },
                    { 38, "Protection and Defense II", "Hilt", "~/Lightsabers/Protection and Defense/PD_Sleeve_2.stl" },
                    { 39, "Protection and Defense III", "Hilt", "~/Lightsabers/Protection and Defense/PD_Sleeve_3.stl" },
                    { 40, "Protection and Defense IV", "Hilt", "~/Lightsabers/Protection and Defense/PD_Sleeve_4.stl" }
                });

            migrationBuilder.InsertData(
                table: "Lightsabers",
                columns: new[] { "lightsaber_id", "Emitter", "Hilt", "Pommel", "Switch", "blade_color", "name" },
                values: new object[] { 1, 3, 7, 5, 1, "Blue", "Example" });

            migrationBuilder.CreateIndex(
                name: "IX_LightsaberComponent_component_id",
                table: "LightsaberComponent",
                column: "component_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LightsaberComponent");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Lightsabers");
        }
    }
}
