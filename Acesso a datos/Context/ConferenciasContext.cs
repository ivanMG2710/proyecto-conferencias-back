using System;
using System.Collections.Generic;
using Acesso_a_datos.Models;
using Microsoft.EntityFrameworkCore;

namespace Acesso_a_datos.Context;

public partial class ConferenciasContext : DbContext
{
    public ConferenciasContext()
    {
    }

    public ConferenciasContext(DbContextOptions<ConferenciasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conferencium> Conferencia { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IVAN\\IVAN;Database=conferencias;Trust Server Certificate=true;User Id=sa;Password=12345678;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conferencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conferen__3213E83FC5F1B5DE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Conferencista)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("conferencista");
            entity.Property(e => e.Fecha)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fecha");
            entity.Property(e => e.Horario)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("horario");
            entity.Property(e => e.NombreConfe)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombreConfe");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3213E83F24E4E329");

            entity.ToTable("Participante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Avatar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Twitter)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("twitter");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registro__3213E83F504B13F3");

            entity.ToTable("Registro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdConferencia).HasColumnName("idConferencia");
            entity.Property(e => e.IdParticipante).HasColumnName("idParticipante");

            entity.HasOne(d => d.IdConferenciaNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdConferencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registro__idConf__286302EC");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdParticipante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registro__idPart__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
