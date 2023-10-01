using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Act1_U2.Models.Entities;

public partial class ZooplanetContext : DbContext
{
    public ZooplanetContext()
    {
    }

    public ZooplanetContext(DbContextOptions<ZooplanetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clase> Clase { get; set; }

    public virtual DbSet<Especies> Especies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=Zooplanet", ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.Idclase).HasName("PRIMARY");

            entity
                .ToTable("clase")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Idclase)
                .ValueGeneratedNever()
                .HasColumnName("idclase");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Especies>(entity =>
        {
            entity.HasKey(e => e.Especie).HasName("PRIMARY");

            entity
                .ToTable("especies")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Clase, "fk_especie_clase_idx");

            entity.Property(e => e.Especie)
                .HasMaxLength(45)
                .HasColumnName("especie");
            entity.Property(e => e.Clase).HasColumnName("clase");
            entity.Property(e => e.Habitat)
                .HasMaxLength(45)
                .HasColumnName("habitat");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .HasColumnName("imagen");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(100)
                .HasColumnName("observaciones");
            entity.Property(e => e.Orden)
                .HasMaxLength(45)
                .HasColumnName("orden");
            entity.Property(e => e.Oviparo).HasColumnName("oviparo");
            entity.Property(e => e.Peso)
                .HasColumnType("double(7,2)")
                .HasColumnName("peso");
            entity.Property(e => e.Tamaño).HasColumnName("tamaño");

            entity.HasOne(d => d.ClaseNavigation).WithMany(p => p.Especies)
                .HasForeignKey(d => d.Clase)
                .HasConstraintName("fk_especie_clase");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
