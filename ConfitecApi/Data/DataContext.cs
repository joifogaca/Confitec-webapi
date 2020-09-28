using ConfitecApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfitecApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Escolaridade> Escolaridades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Password=administradorsql;Persist Security Info=True;User ID=sa;Initial Catalog=master;Data Source=CONFITECSP_WS50");
            }
            
        }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {

            

            builder.Entity<Usuario>()
                .HasData(new List<Usuario>(){
                    new Usuario (1, "Lauro", "Silva", "lsilva@gmail.com", new DateTime(1999,7,7,2,0,0), 1),
                    new Usuario (2, "Roberto", "Silva", "rsilva@gmail.com", new DateTime(1989,9,3,2,0,0), 2),
                    new Usuario (3, "Ronaldo", "Silva", "r.silva@gmail.com", new DateTime(1991,10,20,2,0,0), 3),
                    new Usuario (4, "Rodrigo", "Silva", "r_silva@gmail.com", new DateTime(1992,12,24,2,0,0), 1),
                    new Usuario (5, "Alexandre", "Silva", "lsilva@gmail.com", new DateTime(1995,7,17,2,0,0), 4),
                });

            builder.Entity<Escolaridade>()
                .HasData(new List<Escolaridade>{
                    new Escolaridade (1, "Infantil"),
                    new Escolaridade (2, "Fundamental"),
                    new Escolaridade (3, "Médio"),
                    new Escolaridade (4, "Superior")
                });


        }

    }
}
