using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;

namespace DataAccess.Context
{
    public sealed class XaiBibleContext : DbContext
    {
        public XaiBibleContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<AuthorPlan>()
                .HasKey(t => new { t.BookAuthorId, t.PublicationPlanId });

            modelBuilder.Entity<AuthorPlan>()
                .HasOne(sc => sc.BookAuthor)
                .WithMany(s => s.AuthorPlans)
                .HasForeignKey(sc => sc.BookAuthorId);

            modelBuilder.Entity<AuthorPlan>()
                .HasOne(sc => sc.PublicationPlan)
                .WithMany(c => c.AuthorPlans)
                .HasForeignKey(sc => sc.PublicationPlanId);

            modelBuilder.Entity<ProgramPlan>()
                .HasKey(t => new { t.EducationalProgramId, t.PublicationPlanId });

            modelBuilder.Entity<ProgramPlan>()
                .HasOne(sc => sc.EducationalProgram)
                .WithMany(s => s.ProgramPlans)
                .HasForeignKey(sc => sc.EducationalProgramId);

            modelBuilder.Entity<ProgramPlan>()
                .HasOne(sc => sc.PublicationPlan)
                .WithMany(c => c.ProgramPlans)
                .HasForeignKey(sc => sc.PublicationPlanId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=XAI_BIBLE;Trusted_Connection=True;");
        }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<BookName> BookNames { get; set; }

        public DbSet<BookType> BookTypes { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<EducationalProgram> EducationalPrograms { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<MethodPublication> MethodPublications { get; set; }

        public DbSet<PublicationPlan> PublicationPlans { get; set; }

        public DbSet<PublicationPlanTable> PublicationPlanTables { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<User> Users { get; set; }
    }
}