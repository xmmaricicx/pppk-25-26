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
                entity.HasData(
                     new Doctor { Id = 1, FirstName = "Ana", LastName = "Kovač", SpecialtyId = 1 },
                     new Doctor { Id = 2, FirstName = "Marko", LastName = "Horvat", SpecialtyId = 2 },
                     new Doctor { Id = 3, FirstName = "Ivana", LastName = "Novak", SpecialtyId = 3 },
                     new Doctor { Id = 4, FirstName = "Petar", LastName = "Marić", SpecialtyId = 4 },
                     new Doctor { Id = 5, FirstName = "Lucija", LastName = "Jurić", SpecialtyId = 5 },
                     new Doctor { Id = 6, FirstName = "Tomislav", LastName = "Babić", SpecialtyId = 6 });

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

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasData(
                    new Post { Id = 1, PostalCode = "10000", City = "Zagreb" },
                    new Post { Id = 2, PostalCode = "21000", City = "Split" },
                    new Post { Id = 3, PostalCode = "51000", City = "Rijeka" },
                    new Post { Id = 4, PostalCode = "31000", City = "Osijek" },
                    new Post { Id = 5, PostalCode = "23000", City = "Zadar" },
                    new Post { Id = 6, PostalCode = "10360", City = "Sesvete" });

                entity.HasIndex(p => p.PostalCode).IsUnique();

            });

            modelBuilder.Entity<ExaminationType>(entity =>
            {
                entity.HasData(
                    new ExaminationType { Id = 1, Code = "CT", Name = "Kompjuterizirana tomografija" },
                    new ExaminationType { Id = 2, Code = "MR", Name = "Magnetska rezonanca" },
                    new ExaminationType { Id = 3, Code = "ULTRA", Name = "Ultrazvuk" },
                    new ExaminationType { Id = 4, Code = "EKG", Name = "Elektrokardiogram" },
                    new ExaminationType { Id = 5, Code = "ECHO", Name = "Ehokardiogram" },
                    new ExaminationType { Id = 6, Code = "OKO", Name = "Pregled oka" },
                    new ExaminationType { Id = 7, Code = "DERM", Name = "Dermatološki pregled" },
                    new ExaminationType { Id = 8, Code = "DENTA", Name = "Stomatološki pregled" },
                    new ExaminationType { Id = 9, Code = "MAMMO", Name = "Mamografija" },
                    new ExaminationType { Id = 10, Code = "EEG", Name = "Elektroencefalogram" });

                entity.HasIndex(e => e.Code).IsUnique();
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasData(
                    new Specialty { Id = 1, Name = "Radiologija" },
                    new Specialty { Id = 2, Name = "Kardiologija" },
                    new Specialty { Id = 3, Name = "Oftalmologija" },
                    new Specialty { Id = 4, Name = "Dermatologija" },
                    new Specialty { Id = 5, Name = "Dentalna medicina" },
                    new Specialty { Id = 6, Name = "Neurologija" });

                entity.HasIndex(s => s.Name).IsUnique();
            });

            modelBuilder.Entity<Condition>().HasData(
                new Condition { Id = 1, Name = "Hipertenzija" },
                new Condition { Id = 2, Name = "Dijabetes tipa 2" },
                new Condition { Id = 3, Name = "Astma" },
                new Condition { Id = 4, Name = "Migrena" },
                new Condition { Id = 5, Name = "Fibrilacija atrija" },
                new Condition { Id = 6, Name = "Ekcem" },
                new Condition { Id = 7, Name = "Gastritis" },
                new Condition { Id = 8, Name = "Hipotireoza" });

            modelBuilder.Entity<Medication>().HasData(
                new Medication { Id = 1, Name = "Lisinopril" },
                new Medication { Id = 2, Name = "Metformin" },
                new Medication { Id = 3, Name = "Salbutamol" },
                new Medication { Id = 4, Name = "Sumatriptan" },
                new Medication { Id = 5, Name = "Bisoprolol" },
                new Medication { Id = 6, Name = "Hidrokortizon" },
                new Medication { Id = 7, Name = "Omeprazol" },
                new Medication { Id = 8, Name = "Levotiroksin" });


            modelBuilder.Entity<AddressType>(entity =>
            {

                entity.HasData(
                    new AddressType { Id = 1, Name = "Boravište" },
                    new AddressType { Id = 2, Name = "Prebivalište" });

                entity.HasIndex(at => at.Name).IsUnique();
            });


        }

    }
}
