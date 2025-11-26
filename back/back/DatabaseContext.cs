using back.Model;
using Microsoft.EntityFrameworkCore;

namespace back
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<ForbiddenWord> ForbiddenWords { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Term>().ToTable("Terms");
            modelBuilder.Entity<ForbiddenWord>().ToTable("ForbiddenWords");

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "bob@mail.com", Password = "123", Role = UserRole.ADMIN } ,
                new User { Id = 2, Email = "ross@mail.com", Password = "123", Role = UserRole.USER }
            );

            modelBuilder.Entity<ForbiddenWord>().HasData(
                new ForbiddenWord { Id = 1, Word = "lorem" },
                new ForbiddenWord { Id = 2, Word = "test" },
                new ForbiddenWord { Id = 3, Word = "sample" }
            );

            var seeded = new List<object>();
            var now = DateTime.UtcNow;

            // ---------------------------
            // 50 PUBLISHED TERMS
            // ---------------------------
            string[,] publishedTerms =
            {
                { "photosynthesis", "The biochemical process by which plants convert sunlight, water, and carbon dioxide into oxygen and energy-rich sugars." },
                { "metamorphosis", "A biological process in which an organism undergoes a distinct physical change after birth or hatching." },
                { "plate tectonics", "The scientific theory explaining the movement of Earth's lithospheric plates and the geological events that result from their interactions." },
                { "biodiversity", "The variety of plant and animal life in a particular habitat, ecosystem, or across the entire planet." },
                { "evaporation", "The process by which a liquid transforms into a gas, typically occurring at the surface of the liquid." },
                { "oxidation", "A chemical reaction in which a substance loses electrons, often associated with the interaction of oxygen with other materials." },
                { "mitosis", "A cellular process in which a single cell divides to produce two genetically identical daughter cells." },
                { "ecosystem", "A community of organisms interacting with one another and with their physical environment as a functioning system." },
                { "gravity", "The natural force that attracts objects with mass toward one another, most noticeably toward the center of Earth." },
                { "erosion", "The process by which soil, rock, or other surface material is gradually worn away by wind, water, or ice." },
                { "fusion", "A nuclear reaction in which atomic nuclei combine to form a heavier nucleus, releasing significant energy." },
                { "fission", "A nuclear reaction in which an atomic nucleus splits into smaller nuclei, releasing energy and particles." },
                { "catalyst", "A substance that increases the rate of a chemical reaction without being consumed by the reaction itself." },
                { "antibody", "A protein produced by the immune system that identifies and neutralizes foreign substances such as bacteria or viruses." },
                { "algorithm", "A precise, step-by-step set of instructions used to solve a problem or perform a computation." },
                { "encryption", "The process of converting information into a coded form to prevent unauthorized access." },
                { "compiler", "A software tool that translates source code written in high-level languages into executable machine code." },
                { "cloud computing", "The delivery of computing services, including storage and processing power, over the internet on-demand." },
                { "bandwidth", "The maximum amount of data that can be transmitted over a network connection in a given amount of time." },
                { "quantum computing", "A computing paradigm that uses quantum-mechanical phenomena to perform calculations far more efficiently for certain classes of problems." },
                { "machine learning", "A branch of artificial intelligence allowing systems to learn patterns from data and make decisions with minimal human intervention." },
                { "neural network", "A computational model inspired by the human brain, composed of interconnected nodes that process information." },
                { "photosphere", "The visible surface layer of the sun that emits most of its light and radiation." },
                { "astrobiology", "The scientific study of life in the universe, including its origins, evolution, and possible extraterrestrial existence." },
                { "stratosphere", "The atmospheric layer above the troposphere characterized by stable temperatures and the presence of the ozone layer." },
                { "tectonic uplift", "A geological process in which Earth's crust rises due to structural forces within the mantle." },
                { "sedimentation", "The natural accumulation of particles transported by wind, water, or ice, forming layers of sediment." },
                { "continental drift", "The gradual movement of Earth's continents over geological time due to plate tectonic processes." },
                { "supernova", "A stellar explosion that occurs during the final evolutionary stages of a massive star, producing an extremely bright burst of energy." },
                { "nebula", "A vast cloud of gas and dust in space, often serving as a region where new stars are formed." },
                { "photosphere", "The luminous outer layer of a star from which its light is radiated into space." },
                { "lithosphere", "The rigid outer shell of Earth, composed of the crust and the upper mantle." },
                { "biosphere", "All regions of Earth where life exists, encompassing land, water, and air." },
                { "chromosome", "A DNA-containing structure within cells that carries genetic information in the form of genes." },
                { "antigen", "A foreign substance that triggers an immune system response when detected in the body." },
                { "diffusion", "The movement of particles from an area of higher concentration to an area of lower concentration." },
                { "osmosis", "The diffusion of water across a semipermeable membrane from a region of low solute concentration to high solute concentration." },
                { "atmosphere", "The mixture of gases surrounding a planet, held in place by gravitational forces." },
                { "glacier", "A large, slow-moving mass of ice formed from compacted layers of snow over long periods." },
                { "precipitation", "Any form of water, such as rain, snow, or hail, that falls from the atmosphere to Earth's surface." },
                { "geothermal energy", "Thermal energy generated within Earth that can be harnessed for heating or electricity." },
                { "renewable energy", "Energy collected from resources that replenish naturally, such as solar or wind power." },
                { "carbon cycle", "The natural series of processes by which carbon moves between the atmosphere, oceans, soil, and living organisms." },
                { "hydrosphere", "All the water found on, under, and above the surface of a planet." },
                { "endothermic reaction", "A chemical reaction that absorbs heat from its surroundings as it proceeds." },
                { "exothermic reaction", "A chemical reaction that releases energy in the form of heat or light." },
                { "igneous rock", "A type of rock formed through the cooling and solidification of molten magma or lava." },
                { "sedimentary rock", "A rock type formed from compressed layers of sediment over long geological periods." },
                { "metamorphic rock", "A rock that has been transformed from an existing type through heat, pressure, or chemically active fluids." }
            };

            for (int i = 0; i < publishedTerms.GetLength(0); i++)
            {
                seeded.Add(new
                {
                    Id = i + 1,
                    Name = publishedTerms[i, 0],
                    Definition = publishedTerms[i, 1],
                    Status = TermStatus.PUBLISHED,
                    CreatedById = 1,
                    CreatedAt = now - Random.Shared.Next(1, 100) * TimeSpan.FromDays(1)
                });
            }

            // ---------------------------
            // 4 ARCHIVED TERMS
            //---------------------------
            seeded.AddRange(new[]
            {
                new {
                    Id = 51,
                    Name = "ether theory",
                    Definition = "A historical scientific concept once believed to explain the propagation of light through a universal medium.",
                    Status = TermStatus.ARCHIVED,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                },
                new {
                    Id = 52,
                    Name = "phlogiston",
                    Definition = "A defunct scientific theory that proposed the existence of a fire-like element released during combustion.",
                    Status = TermStatus.ARCHIVED,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                },
                new {
                    Id = 53,
                    Name = "luminiferous ether",
                    Definition = "A superseded hypothesis that claimed empty space was filled with a medium through which light waves traveled.",
                    Status = TermStatus.ARCHIVED,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                },
                new {
                    Id = 54,
                    Name = "vitalism",
                    Definition = "An outdated belief that living organisms are fundamentally different from non-living entities due to a vital force.",
                    Status = TermStatus.ARCHIVED,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                }
            });

            // ---------------------------
            // 5 DRAFT TERMS
            // ---------------------------
            seeded.AddRange(new[]
            {
                new {
                    Id = 55,
                    Name = "quantum entanglement",
                    Definition = "A physical phenomenon where particles remain interconnected such that the state of one instantly influences the other.",
                    Status = TermStatus.DRAFT,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                },
                new {
                    Id = 56,
                    Name = "dark matter",
                    Definition = "A form of matter thought to account for most of the mass in the universe, detectable through its gravitational effects.",
                    Status = TermStatus.DRAFT,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                },
                new {
                    Id = 57,
                    Name = "cryosphere",
                    Definition = "All of Earth's frozen water, including glaciers, sea ice, and permafrost regions.",
                    Status = TermStatus.DRAFT,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                },
                new {
                    Id = 58,
                    Name = "photosynthetic efficiency",
                    Definition = "The ratio of captured solar energy to biomass produced by photosynthetic organisms.",
                    Status = TermStatus.DRAFT,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                },
                new {
                    Id = 59,
                    Name = "bioluminescence",
                    Definition = "The production of visible light by living organisms through chemical reactions within their bodies.",
                    Status = TermStatus.DRAFT,
                    CreatedById = 1,
                    CreatedAt = now - TimeSpan.FromDays(Random.Shared.Next(10, 20))
                }
            });

            modelBuilder.Entity<Term>().HasData(seeded);
        }

    }
}
