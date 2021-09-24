using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebEmployees.Domain.Entities;

namespace WebEmployees.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(x => new { x.PersonnelNumber, x.StaffMember,x.Id });
            //modelBuilder.Entity<Employee>().Property(m => m.PersonnelNumber).IsRequired();
        }
    }
}
