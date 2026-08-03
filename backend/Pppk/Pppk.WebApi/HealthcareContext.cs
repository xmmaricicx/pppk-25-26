using Microsoft.EntityFrameworkCore;
using Pppk.WebApi.Models;

namespace Pppk.WebApi
{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext()
        {
        }
        public HealthcareContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ExaminationType> ExaminationTypes { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAddress> PatientAddresses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<SpecialtyExaminationType> SpecialtyExaminationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasIndex(a => new { a.DoctorId, a.ScheduledAt }).IsUnique();
                entity.HasIndex(a => new { a.PatientId, a.ScheduledAt }).IsUnique();

                entity.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.ExaminationType)
                .WithMany(et => et.Appointments)
                .HasForeignKey(a => a.ExaminationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasOne(d => d.Specialty)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<MedicalHistory>(entity =>
            {
                entity.HasIndex(mh => new { mh.PatientId, mh.ConditionId, mh.StartDate }).IsUnique();

                entity.HasOne(mh => mh.Patient)
                .WithMany(p => p.MedicalHistories)
                .HasForeignKey(mh => mh.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mh => mh.Condition)
                .WithMany(c => c.MedicalHistories)
                .HasForeignKey(mh => mh.ConditionId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<PatientAddress>(entity =>
            {
                entity.HasIndex(pa => new { pa.PatientId, pa.AddressTypeId }).IsUnique();

                entity.HasOne(pa => pa.Patient)
                .WithMany(p => p.PatientAddresses)
                .HasForeignKey(pa => pa.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pa => pa.AddressType)
                .WithMany(at => at.PatientAddresses)
                .HasForeignKey(pa => pa.AddressTypeId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pa => pa.Address)
                .WithMany(a => a.PatientAddresses)
                .HasForeignKey(pa => pa.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasIndex(pr => new { pr.PatientId, pr.MedicationId, pr.ConditionId }).IsUnique();

                entity.HasOne(pr => pr.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pr => pr.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pr => pr.Medication)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(pr => pr.MedicationId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pr => pr.Condition)
                .WithMany(c => c.Prescriptions)
                .HasForeignKey(pr => pr.ConditionId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SpecialtyExaminationType>(entity =>
            {
                entity.HasKey(se => new { se.SpecialtyId, se.ExaminationTypeId });

                entity.HasOne(se => se.Specialty)
                .WithMany(s => s.SpecialtyExaminationTypes)
                .HasForeignKey(se => se.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(se => se.ExaminationType)
                .WithMany(et => et.SpecialtyExaminationTypes)
                .HasForeignKey(se => se.ExaminationTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(p => p.Gender)
                .HasConversion<string>()
                .HasMaxLength(10);

                entity.HasIndex(p => p.Oib).IsUnique();
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(a => a.Post)
                .WithMany(p => p.Addresses)
                .HasForeignKey(a => a.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Post>().HasIndex(p => p.PostalCode).IsUnique();
            modelBuilder.Entity<ExaminationType>().HasIndex(e => e.Code).IsUnique();
            modelBuilder.Entity<Specialty>().HasIndex(s => s.Name).IsUnique();

        }

    }
}
