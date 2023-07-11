using BeautySalon.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BeautySalon.DataBase
{
    public class BeautySalonDbContext : DbContext
    {

        public BeautySalonDbContext(DbContextOptions<BeautySalonDbContext> options) : base(options)
        {

        }

        public DbSet<Service> Services { get; set; }
    }
}