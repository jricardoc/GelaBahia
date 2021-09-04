using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GelaBahia.Models;

namespace GelaBahia.Data
{
    public class GelaBahiaContext : DbContext
    {
        public GelaBahiaContext (DbContextOptions<GelaBahiaContext> options)
            : base(options)
        {
        }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Servico> Servico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionario");
            modelBuilder.Entity<Servico>().ToTable("Servico");
        }

    }
}
