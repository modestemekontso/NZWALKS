using Microsoft.EntityFrameworkCore;
using NZWalks.Model.Domain;

namespace NZWalk.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
     
        {
                   
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for difficulties
            //Esay,Medium,hard

            var difficulties = new List<Difficulty>()
            {
             new Difficulty()
             {
                 Id=Guid.Parse("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6b"),
                  Name="Easy"
                   
             },

             new Difficulty()
             {
                 Id=Guid.Parse("d06e77c7-4733-498d-9122-6260b242d909"),
                  Name="Medium"
             },

             new Difficulty()
             {
                 Id=Guid.Parse("eb24c4a5-c67a-4eee-ae3b-e17bb9a79dd0"),
                  Name="Hard"
             }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed data for Regions

            var regions = new List<Region>()
            {
                 new Region()
                 {
                     Id=Guid.Parse("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6b"),
                      Name="Easy",
                       Code="AML",
                        RegionImageUrl=""
                 },

                new Region()
                 {
                     Id=Guid.Parse("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6c"),
                      Name="Easy",
                       Code="AML",
                        RegionImageUrl=""
                 },

                new Region()
                 {
                     Id=Guid.Parse("cb7f246a-9c95-491d-a4e2-eaa74fd1fa6d"),
                      Name="Easy",
                       Code="AML",
                        RegionImageUrl=""
                 },
               
            };
            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
