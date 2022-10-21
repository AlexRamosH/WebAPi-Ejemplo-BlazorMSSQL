using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorApp3.Shared;
namespace BlazorApp3.Server.DataAccess
{
    /// <summary>
    /// Realiza las configuraciones nesesarias para mantener la
    /// relacion con la base de datos, sus tablas y los campos en este.
    /// 
    /// </summary>
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



        /// <summary>
        /// Se crean un modelo por cada tabla que desea ser agregada, dentro de esta
        /// se definen los capos de la tabla y con que clase y atributo se relaciona
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoI>(entity =>
            {
                entity.ToTable("TODO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Terminado).HasColumnName("TERMINADO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
