using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

public partial class BdPrecetasContext : IdentityDbContext<ApplicationUser,IdentityRole,int>
{
    public BdPrecetasContext()
    {
    }

    public BdPrecetasContext(DbContextOptions<BdPrecetasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Complejidad> Complejidads { get; set; }

    public virtual DbSet<EstatusReporte> EstatusReportes { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<ReportesComentario> ReportesComentarios { get; set; }

    public virtual DbSet<ReportesReceta> ReportesRecetas { get; set; }

    public virtual DbSet<Tiempo> Tiempos { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<ValoracionReceta> ValoracionRecetas { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comentar__3213E83F432299F6");

            entity.HasOne(d => d.Receta).WithMany(p => p.Comentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comentari__recet__6D0D32F4");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comentari__usuar__6C190EBB");
        });

        modelBuilder.Entity<Complejidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__compleji__3213E83F227FA4CF");
        });

        modelBuilder.Entity<EstatusReporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estatus___3213E83FCFDFA416");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permisos__3213E83F91993429");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recetas__3213E83F73B6A0C7");

            entity.Property(e => e.Visitas).HasDefaultValue(0);

            entity.HasOne(d => d.ComplejidadNivelNavigation).WithMany(p => p.Receta)
                .HasPrincipalKey(p => p.Nivel)
                .HasForeignKey(d => d.ComplejidadNivel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__complej__6754599E");

            entity.HasOne(d => d.Estatus).WithMany(p => p.Receta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__estatus__693CA210");

            entity.HasOne(d => d.RangoTiempoNavigation).WithMany(p => p.Receta)
                .HasPrincipalKey(p => p.Rango)
                .HasForeignKey(d => d.RangoTiempo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__rango_t__68487DD7");

            entity.HasOne(d => d.RegionNombreNavigation).WithMany(p => p.Receta)
                .HasPrincipalKey(p => p.Nombre)
                .HasForeignKey(d => d.RegionNombre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__region___656C112C");

            entity.HasOne(d => d.TipoNombreNavigation).WithMany(p => p.Receta)
                .HasPrincipalKey(p => p.Nombre)
                .HasForeignKey(d => d.TipoNombre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__tipo_no__66603565");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Receta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__usuario__6477ECF3");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__region__3213E83F54C1C73C");
        });

        modelBuilder.Entity<ReportesComentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reportes__3213E83F142F5500");

            entity.HasOne(d => d.Comentario).WithMany(p => p.ReportesComentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___comen__73BA3083");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.ReportesComentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___estat__74AE54BC");
        });

        modelBuilder.Entity<ReportesReceta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reportes__3213E83FBCA7C5A1");

            entity.HasOne(d => d.Estatus).WithMany(p => p.ReportesReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___estat__787EE5A0");

            entity.HasOne(d => d.Receta).WithMany(p => p.ReportesReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___recet__778AC167");
        });



        modelBuilder.Entity<Tiempo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tiempo__3213E83F7723ED9F");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipo__3213E83F218B9CA3");
        });

        modelBuilder.Entity<ValoracionReceta>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.RecetaId }).HasName("PK__valoraci__6A6B78C4F6CD87C9");

            entity.HasOne(d => d.Receta).WithMany(p => p.ValoracionReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__valoracio__recet__70DDC3D8");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ValoracionReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__valoracio__usuar__6FE99F9F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
