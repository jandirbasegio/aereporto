using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aeroporto.Models;

public partial class AeroportoContext : DbContext
{
    public AeroportoContext()
    {
    }

    public AeroportoContext(DbContextOptions<AeroportoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronave> Aeronaves { get; set; }

    public virtual DbSet<ClientesPreferenciais> ClientesPreferenciais { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Poltrona> Assento { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Voo> Voos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Aeroporto;User ID=;Password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Aeronave__3213E83FB5DCAF21");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NumeroAssento).HasColumnName("numero_Assento");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<ClientesPreferenciais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F49355665");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Gestante)
                .HasMaxLength(4)
                .HasColumnName("gestante");
            entity.Property(e => e.Idoso)
                .HasMaxLength(4)
                .HasColumnName("idoso");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Escala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Escalas__3213E83FCF58F572");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AeroportoSaida)
                .HasMaxLength(100)
                .HasColumnName("aeroporto_saida");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("horario_saida");
            entity.Property(e => e.VooId).HasColumnName("voo_id");

            entity.HasOne(d => d.Voo).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.VooId)
                .HasConstraintName("FK__Escalas__voo_id__3B75D760");
        });

        modelBuilder.Entity<Poltrona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Poltrona__3213E83F96B6E083");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AeronaveId).HasColumnName("aeronave_id");
            entity.Property(e => e.Disponibilidade)
                .HasMaxLength(15)
                .HasColumnName("disponibilidade");
            entity.Property(e => e.Localizacao)
                .HasMaxLength(20)
                .HasColumnName("localizacao");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");

            entity.HasOne(d => d.Aeronave).WithMany(p => p.Assento)
                .HasForeignKey(d => d.AeronaveId)
                .HasConstraintName("FK__Assento__dispo__3E52440B");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3213E83FF7558A66");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.PoltronaId).HasColumnName("poltrona_id");
            entity.Property(e => e.VooId).HasColumnName("voo_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Reservas__client__44FF419A");

            entity.HasOne(d => d.Poltrona).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.PoltronaId)
                .HasConstraintName("FK__Reservas__poltro__440B1D61");

            entity.HasOne(d => d.Voo).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.VooId)
                .HasConstraintName("FK__Reservas__voo_id__4316F928");
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voos__3213E83F2C326BB0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AeronaveId).HasColumnName("aeronave_id");
            entity.Property(e => e.AeroportoDestino)
                .HasMaxLength(100)
                .HasColumnName("aeroporto_destino");
            entity.Property(e => e.AeroportoOrigem)
                .HasMaxLength(100)
                .HasColumnName("aeroporto_origem");
            entity.Property(e => e.HorarioPrevistoChegada)
                .HasColumnType("datetime")
                .HasColumnName("horario_previsto_chegada");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("horario_saida");

            entity.HasOne(d => d.Aeronave).WithMany(p => p.Voos)
                .HasForeignKey(d => d.AeronaveId)
                .HasConstraintName("FK__Voos__aeronave_i__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
