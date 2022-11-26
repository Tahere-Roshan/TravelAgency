using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Model;

namespace TravelAgency.Model
{
    public class TourContext : DbContext
    {
        //DbSet<Tour> _dbSet;
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Employee> Employee { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            //DB file path
           // string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.ToString() + Path.Combine(Path.DirectorySeparatorChar.ToString(), "TravelAgency.db");
            //Console.WriteLine(path);
            //Database file. When using migrations in console app, absolute path necessary
            //string newpath = @"D:\Tahi\West uni\Modules\Master in IT and Management\Cources\3 - Full - Stack\Specialist Lectures\DataDtorage\Assignment\Lab\TravelAgency\TravelAgency\TravelAgencyDB.db";
            optionsbuilder.UseSqlite(@"DataSource= D:\DataStorag\TravelAgency\TravelAgency.db");// + path);
            //string newpath= 
        }


       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //1:M Relationship
            //reference-https://www.learnentityframeworkcore.com/configuration/one-to-many-relationship-configuration
            *//*modelBuilder.Entity<Tour>()
                .HasMany(b => b.Customer)
                .WithOne(c => c.Tour);*//*


            //Create M:M relationship-each custore has several reserv/each reserv has several customer
            //Add PK for Reservation
            modelBuilder.Entity<Reservations>()
                .HasKey(k => new { k.CustomerId, k.TourID });

            //Add Relation to Tour from Reservation
            modelBuilder.Entity<Reservations>()
                .HasOne(b => b.Tour)
                .WithMany(bc => bc.Reservations)
                .HasForeignKey(d => d.TourID);

            //Add Relation to Customer from Reservation
            modelBuilder.Entity<Reservations>()
                .HasOne(b => b.Customer)
                .WithMany(bc => bc.Reservations)
                .HasForeignKey(d => d.CustomerId);



        }
*/

    }
}
