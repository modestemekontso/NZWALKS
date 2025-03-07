﻿using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Model.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalkDbContext:DbContext
    {
        public NZWalkDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walk { get; set; }
    }
}
