using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorApp3.Shared;
namespace BlazorApp3.Server.DataAccess
{
    public partial class TODOContext : DbContext
    {
        public TODOContext()
        {
        }

        public TODOContext(DbContextOptions<TODOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TodoI> Todos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoI>(entity =>
            {
                entity.ToTable("TODO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descrpcion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DESCRPCION");

                entity.Property(e => e.Terminado).HasColumnName("TERMINADO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
