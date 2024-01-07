using EgitimPortaliWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortaliWebApi.Data
{
    public class EgitimPortaliContext : DbContext
    {
        public EgitimPortaliContext(DbContextOptions<EgitimPortaliContext> options) : base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Lecture - Field ilişkisi (n-1)
            modelBuilder.Entity<Lecture>()
                .HasOne(l => l.Field)
                .WithMany(f => f.Lectures)
                .HasForeignKey(l => l.FieldId)
                .OnDelete(DeleteBehavior.NoAction);

            // Student - Field ilişkisi (n-1)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Field)
                .WithMany(f => f.Students)
                .HasForeignKey(s => s.FieldId)
                .OnDelete(DeleteBehavior.NoAction);

            // Teacher - Field ilişkisi (n-1)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Field)
                .WithMany(f => f.Teachers)
                .HasForeignKey(t => t.FieldId)
                .OnDelete(DeleteBehavior.NoAction);
            
            // Lecture - Teacher ilişkisi (n-1)
            modelBuilder.Entity<Lecture>()
                .HasOne(l => l.Teacher)
                .WithMany(t => t.Lectures)
                .HasForeignKey(l => l.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            // Article - Teacher ilişkisi (n-1)
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Teacher)
                .WithMany(t => t.Articles)
                .HasForeignKey(a => a.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);
            
            // Lecture - Student ilişkisi (n-n)
            modelBuilder.Entity<Lecture>()
                .HasMany(l => l.Students)
                .WithMany(s => s.Lectures)
                .UsingEntity(j => j.ToTable("LecturesStudents"));
        }
    }
}
