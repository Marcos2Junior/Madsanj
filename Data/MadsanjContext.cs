using Data.ModelDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Data
{
    public class MadsanjContext : DbContext
    {
        public MadsanjContext(DbContextOptions<MadsanjContext> options)
            : base(options)
        {
        }

        public DbSet<Financeiro> Financeiro { get; set; }
        public DbSet<FinanceiroParcela> FinanceiroParcela { get; set; }
        public DbSet<ExceptionFull> ExceptionFull { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinanceiroParcela>()
                .HasOne(x => x.Financeiro)
                .WithMany(x => x.FinanceiroParcelas)
                .HasForeignKey(x => x.FinanceiroId);

            modelBuilder.Entity<Financeiro>().Property(x => x.ValorTotal).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<FinanceiroParcela>().Property(x => x.ValorParcela).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<FinanceiroParcela>().Property(x => x.MultaAtraso).HasColumnType("decimal(10, 2)");
        }
    }
}
