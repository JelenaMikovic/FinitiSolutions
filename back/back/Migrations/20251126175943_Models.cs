using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForbiddenWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Word = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForbiddenWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Definition = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terms_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ForbiddenWords",
                columns: new[] { "Id", "Word" },
                values: new object[,]
                {
                    { 1, "lorem" },
                    { 2, "test" },
                    { 3, "sample" }
                });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Definition", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 8, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The biochemical process by which plants convert sunlight, water, and carbon dioxide into oxygen and energy-rich sugars.", "photosynthesis", 0 },
                    { 2, new DateTime(2025, 11, 17, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A biological process in which an organism undergoes a distinct physical change after birth or hatching.", "metamorphosis", 0 },
                    { 3, new DateTime(2025, 10, 29, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The scientific theory explaining the movement of Earth's lithospheric plates and the geological events that result from their interactions.", "plate tectonics", 0 },
                    { 4, new DateTime(2025, 10, 8, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The variety of plant and animal life in a particular habitat, ecosystem, or across the entire planet.", "biodiversity", 0 },
                    { 5, new DateTime(2025, 11, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The process by which a liquid transforms into a gas, typically occurring at the surface of the liquid.", "evaporation", 0 },
                    { 6, new DateTime(2025, 8, 19, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A chemical reaction in which a substance loses electrons, often associated with the interaction of oxygen with other materials.", "oxidation", 0 },
                    { 7, new DateTime(2025, 10, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A cellular process in which a single cell divides to produce two genetically identical daughter cells.", "mitosis", 0 },
                    { 8, new DateTime(2025, 10, 3, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A community of organisms interacting with one another and with their physical environment as a functioning system.", "ecosystem", 0 },
                    { 9, new DateTime(2025, 10, 29, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The natural force that attracts objects with mass toward one another, most noticeably toward the center of Earth.", "gravity", 0 },
                    { 10, new DateTime(2025, 9, 16, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The process by which soil, rock, or other surface material is gradually worn away by wind, water, or ice.", "erosion", 0 },
                    { 11, new DateTime(2025, 10, 26, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A nuclear reaction in which atomic nuclei combine to form a heavier nucleus, releasing significant energy.", "fusion", 0 },
                    { 12, new DateTime(2025, 10, 22, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A nuclear reaction in which an atomic nucleus splits into smaller nuclei, releasing energy and particles.", "fission", 0 },
                    { 13, new DateTime(2025, 8, 24, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A substance that increases the rate of a chemical reaction without being consumed by the reaction itself.", "catalyst", 0 },
                    { 14, new DateTime(2025, 9, 4, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A protein produced by the immune system that identifies and neutralizes foreign substances such as bacteria or viruses.", "antibody", 0 },
                    { 15, new DateTime(2025, 9, 9, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A precise, step-by-step set of instructions used to solve a problem or perform a computation.", "algorithm", 0 },
                    { 16, new DateTime(2025, 8, 20, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The process of converting information into a coded form to prevent unauthorized access.", "encryption", 0 },
                    { 17, new DateTime(2025, 9, 19, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A software tool that translates source code written in high-level languages into executable machine code.", "compiler", 0 },
                    { 18, new DateTime(2025, 10, 3, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The delivery of computing services, including storage and processing power, over the internet on-demand.", "cloud computing", 0 },
                    { 19, new DateTime(2025, 9, 2, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The maximum amount of data that can be transmitted over a network connection in a given amount of time.", "bandwidth", 0 },
                    { 20, new DateTime(2025, 10, 4, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A computing paradigm that uses quantum-mechanical phenomena to perform calculations far more efficiently for certain classes of problems.", "quantum computing", 0 },
                    { 21, new DateTime(2025, 11, 12, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A branch of artificial intelligence allowing systems to learn patterns from data and make decisions with minimal human intervention.", "machine learning", 0 },
                    { 22, new DateTime(2025, 9, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A computational model inspired by the human brain, composed of interconnected nodes that process information.", "neural network", 0 },
                    { 23, new DateTime(2025, 10, 15, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The visible surface layer of the sun that emits most of its light and radiation.", "photosphere", 0 },
                    { 24, new DateTime(2025, 10, 15, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The scientific study of life in the universe, including its origins, evolution, and possible extraterrestrial existence.", "astrobiology", 0 },
                    { 25, new DateTime(2025, 10, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The atmospheric layer above the troposphere characterized by stable temperatures and the presence of the ozone layer.", "stratosphere", 0 },
                    { 26, new DateTime(2025, 9, 27, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A geological process in which Earth's crust rises due to structural forces within the mantle.", "tectonic uplift", 0 },
                    { 27, new DateTime(2025, 9, 9, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The natural accumulation of particles transported by wind, water, or ice, forming layers of sediment.", "sedimentation", 0 },
                    { 28, new DateTime(2025, 10, 3, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The gradual movement of Earth's continents over geological time due to plate tectonic processes.", "continental drift", 0 },
                    { 29, new DateTime(2025, 8, 20, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A stellar explosion that occurs during the final evolutionary stages of a massive star, producing an extremely bright burst of energy.", "supernova", 0 },
                    { 30, new DateTime(2025, 10, 27, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A vast cloud of gas and dust in space, often serving as a region where new stars are formed.", "nebula", 0 },
                    { 31, new DateTime(2025, 11, 11, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The luminous outer layer of a star from which its light is radiated into space.", "photosphere", 0 },
                    { 32, new DateTime(2025, 9, 19, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The rigid outer shell of Earth, composed of the crust and the upper mantle.", "lithosphere", 0 },
                    { 33, new DateTime(2025, 11, 22, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "All regions of Earth where life exists, encompassing land, water, and air.", "biosphere", 0 },
                    { 34, new DateTime(2025, 11, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A DNA-containing structure within cells that carries genetic information in the form of genes.", "chromosome", 0 },
                    { 35, new DateTime(2025, 9, 30, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A foreign substance that triggers an immune system response when detected in the body.", "antigen", 0 },
                    { 36, new DateTime(2025, 10, 17, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The movement of particles from an area of higher concentration to an area of lower concentration.", "diffusion", 0 },
                    { 37, new DateTime(2025, 10, 1, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The diffusion of water across a semipermeable membrane from a region of low solute concentration to high solute concentration.", "osmosis", 0 },
                    { 38, new DateTime(2025, 10, 5, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The mixture of gases surrounding a planet, held in place by gravitational forces.", "atmosphere", 0 },
                    { 39, new DateTime(2025, 11, 4, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A large, slow-moving mass of ice formed from compacted layers of snow over long periods.", "glacier", 0 },
                    { 40, new DateTime(2025, 11, 3, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "Any form of water, such as rain, snow, or hail, that falls from the atmosphere to Earth's surface.", "precipitation", 0 },
                    { 41, new DateTime(2025, 11, 19, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "Thermal energy generated within Earth that can be harnessed for heating or electricity.", "geothermal energy", 0 },
                    { 42, new DateTime(2025, 9, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "Energy collected from resources that replenish naturally, such as solar or wind power.", "renewable energy", 0 },
                    { 43, new DateTime(2025, 9, 30, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The natural series of processes by which carbon moves between the atmosphere, oceans, soil, and living organisms.", "carbon cycle", 0 },
                    { 44, new DateTime(2025, 11, 22, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "All the water found on, under, and above the surface of a planet.", "hydrosphere", 0 },
                    { 45, new DateTime(2025, 10, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A chemical reaction that absorbs heat from its surroundings as it proceeds.", "endothermic reaction", 0 },
                    { 46, new DateTime(2025, 9, 28, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A chemical reaction that releases energy in the form of heat or light.", "exothermic reaction", 0 },
                    { 47, new DateTime(2025, 8, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A type of rock formed through the cooling and solidification of molten magma or lava.", "igneous rock", 0 },
                    { 48, new DateTime(2025, 9, 12, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A rock type formed from compressed layers of sediment over long geological periods.", "sedimentary rock", 0 },
                    { 49, new DateTime(2025, 11, 22, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A rock that has been transformed from an existing type through heat, pressure, or chemically active fluids.", "metamorphic rock", 0 },
                    { 51, new DateTime(2025, 11, 9, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A historical scientific concept once believed to explain the propagation of light through a universal medium.", "ether theory", 2 },
                    { 52, new DateTime(2025, 11, 13, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A defunct scientific theory that proposed the existence of a fire-like element released during combustion.", "phlogiston", 2 },
                    { 53, new DateTime(2025, 11, 8, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A superseded hypothesis that claimed empty space was filled with a medium through which light waves traveled.", "luminiferous ether", 2 },
                    { 54, new DateTime(2025, 11, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "An outdated belief that living organisms are fundamentally different from non-living entities due to a vital force.", "vitalism", 2 },
                    { 55, new DateTime(2025, 11, 15, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A physical phenomenon where particles remain interconnected such that the state of one instantly influences the other.", "quantum entanglement", 1 },
                    { 56, new DateTime(2025, 11, 8, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "A form of matter thought to account for most of the mass in the universe, detectable through its gravitational effects.", "dark matter", 1 },
                    { 57, new DateTime(2025, 11, 14, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "All of Earth's frozen water, including glaciers, sea ice, and permafrost regions.", "cryosphere", 1 },
                    { 58, new DateTime(2025, 11, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The ratio of captured solar energy to biomass produced by photosynthetic organisms.", "photosynthetic efficiency", 1 },
                    { 59, new DateTime(2025, 11, 7, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009), 1, "The production of visible light by living organisms through chemical reactions within their bodies.", "bioluminescence", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Terms_CreatedById",
                table: "Terms",
                column: "CreatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForbiddenWords");

            migrationBuilder.DropTable(
                name: "Terms");
        }
    }
}
