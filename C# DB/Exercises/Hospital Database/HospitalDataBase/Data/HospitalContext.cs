using HospitalDataBase.Data;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<PatientMedicament> GetPatientMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(k => k.PatientId);

                p.Property(f => f.FirstName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                p.Property(l => l.LastName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                p.Property(a => a.Address)
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode(true);

                p.Property(e => e.Email)
                .HasMaxLength(80)
                .IsRequired(true)
                .IsUnicode(false);

                p.Property(h => h.HasInsurance)
                .IsRequired(true)
                .HasColumnType("BIT");
                
            });

            modelBuilder.Entity<Visitation>(v =>
            {
                v.HasKey(k => k.VisitationId);

                v.Property(d => d.Date)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

                v.Property(c => c.Comments)
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode(true);

            });

            modelBuilder.Entity<Diagnose>(d =>
            {
                d.HasKey(k => k.DiagnoseId);

                d.Property(n => n.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                d.Property(c => c.Comments)
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasKey(k => k.MedicamentId);

                m.Property(n => n.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);
            });

            modelBuilder.Entity<PatientMedicament>(pm =>
            {
                pm.HasKey(k => new
                {
                    k.MedicamentId,
                    k.PatientId
                });

                pm.HasOne(p => p.Patient)
                .WithMany(pr => pr.Prescriptions)
                .HasForeignKey(p=> p.PatientId);

                pm.HasOne(m => m.Medicament)
                .WithMany(pr => pr.Prescriptions)
                .HasForeignKey(m => m.MedicamentId);

            });
            
        }
    }
}
