using Microsoft.EntityFrameworkCore;
using Timesheets.DataLayer.Models;

namespace Timesheets.DataLayer
{
    public class TimesheetDbContext : DbContext
    {
        public TimesheetDbContext(DbContextOptions<TimesheetDbContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        }

        // table access
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // db access settings
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    // BAD EXAMPLE
        //    //optionsBuilder.UseSqlite(@"Data Source=timesheets.db;");
        //}


        //// data model settings
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //modelBuilder.Entity<User>().Ignore(e => e.Role);
        //}
    }
}
