using Microsoft.EntityFrameworkCore;
using LearnValuate.Models;

namespace LearnValuate.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<VideoFeedback> VideoFeedbacks { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Map to existing table names if they are plural/lowercase in PHP
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Course>().ToTable("courses");
        modelBuilder.Entity<Video>().ToTable("videos");
        modelBuilder.Entity<VideoFeedback>().ToTable("video_feedback");
        modelBuilder.Entity<Payment>().ToTable("payments");
        modelBuilder.Entity<Certificate>().ToTable("certificates");
        
        modelBuilder.Entity<User>().Property(e => e.Id).HasColumnName("id");
        modelBuilder.Entity<User>().Property(e => e.Username).HasColumnName("username");
        modelBuilder.Entity<User>().Property(e => e.Email).HasColumnName("email");
        modelBuilder.Entity<User>().Property(e => e.Password).HasColumnName("password");
        modelBuilder.Entity<User>().Property(e => e.Role).HasColumnName("role");

        modelBuilder.Entity<Course>().Property(e => e.Id).HasColumnName("id");
        modelBuilder.Entity<Course>().Property(e => e.TutorName).HasColumnName("tutor_name");
        modelBuilder.Entity<Course>().Property(e => e.LogoFile).HasColumnName("logo_file");
        modelBuilder.Entity<Course>().Property(e => e.Description).HasColumnName("description");
        
        modelBuilder.Entity<Video>().Property(e => e.Id).HasColumnName("id");
        modelBuilder.Entity<Video>().Property(e => e.Title).HasColumnName("title");
        modelBuilder.Entity<Video>().Property(e => e.VideoUrl).HasColumnName("video_url");
        modelBuilder.Entity<Video>().Property(e => e.CourseId).HasColumnName("course_id");

        modelBuilder.Entity<VideoFeedback>().Property(e => e.Id).HasColumnName("id");
        modelBuilder.Entity<VideoFeedback>().Property(e => e.VideoId).HasColumnName("video_id");
        modelBuilder.Entity<VideoFeedback>().Property(e => e.IsLiked).HasColumnName("is_liked");
        modelBuilder.Entity<VideoFeedback>().Property(e => e.Comment).HasColumnName("comment");

        modelBuilder.Entity<Payment>().Property(e => e.Id).HasColumnName("id");
        modelBuilder.Entity<Payment>().Property(e => e.Method).HasColumnName("method");
        modelBuilder.Entity<Payment>().Property(e => e.CardNumber).HasColumnName("card_number");
        modelBuilder.Entity<Payment>().Property(e => e.Expiry).HasColumnName("expiry");
        modelBuilder.Entity<Payment>().Property(e => e.Cvv).HasColumnName("cvv");
        modelBuilder.Entity<Payment>().Property(e => e.Phone).HasColumnName("phone");
        modelBuilder.Entity<Payment>().Property(e => e.TransactionId).HasColumnName("transaction_id");
        modelBuilder.Entity<Payment>().Property(e => e.Email).HasColumnName("email");
        modelBuilder.Entity<Payment>().Property(e => e.SubmittedAt).HasColumnName("submitted_at");
        modelBuilder.Entity<Payment>().Property(e => e.Course).HasColumnName("course");

        modelBuilder.Entity<Certificate>().Property(e => e.Id).HasColumnName("id");
        modelBuilder.Entity<Certificate>().Property(e => e.UserName).HasColumnName("user_name");
        modelBuilder.Entity<Certificate>().Property(e => e.DateIssued).HasColumnName("date_issued");

        modelBuilder.Entity<Enrollment>().ToTable("enrollments");
        modelBuilder.Entity<Enrollment>().Property(e => e.EnrollmentId).HasColumnName("enrollment_id");
        modelBuilder.Entity<Enrollment>().Property(e => e.UserId).HasColumnName("user_id");
        modelBuilder.Entity<Enrollment>().Property(e => e.CourseId).HasColumnName("course_id");
        modelBuilder.Entity<Enrollment>().Property(e => e.EnrollmentDate).HasColumnName("enrollment_date");
    }
}
