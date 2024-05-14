using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GunsOfTheOldWest.Ui.Mvc.Models;
using System;

namespace GunsOfTheOldWest.Ui.Mvc.Core
{
    public class GunsOfTheOldWestDbContext : DbContext
    {
        public GunsOfTheOldWestDbContext(DbContextOptions<GunsOfTheOldWestDbContext> options) : base(options)
        {
            
        }

        public DbSet<Winner> Winners => Set<Winner>();

    }
}
