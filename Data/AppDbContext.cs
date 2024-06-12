using reSmart.Models;

namespace reSmart.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserTesting> UserTestings { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-P4BJ7GD;Database=reSmart;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.IdRole);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.IdCourse);

            modelBuilder.Entity<Enrollment>()
                .HasKey(enr => enr.IdEnrollment);

            modelBuilder.Entity<Subject>()
                .HasKey(s => s.IdSubject);

            modelBuilder.Entity<Review>()
                .HasKey(rev => rev.IdReview);

            modelBuilder.Entity<Test>()
                .HasKey(t => t.IdTest);

            modelBuilder.Entity<UserTesting>()
                .HasKey(ut => ut.IdUserTesting);

            modelBuilder.Entity<Lesson>()
                .HasKey(l => new { l.IdLesson, l.CourseId });

            modelBuilder.Entity<Content>()
                .HasKey(ctn => new { ctn.IdContent, ctn.LessonId, ctn.CourseId });

            modelBuilder.Entity<Question>()
                .HasKey(q => new { q.IdQuestion, q.TestId});

            modelBuilder.Entity<Answer>()
                .HasKey(a => new { a.IdAnswer, a.QuestionId, a.TestId });

            modelBuilder.Entity<UserAnswers>()
                .HasKey(ua => new { ua.IdUserAnswers, ua.UserTestingId});


            // role - user (1:m)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // user - enrollment (1:m)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Enrollments)
                .WithOne(enr => enr.User)
                .HasForeignKey(enr => enr.UserId);

            // course - enrollment (1:m)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(enr => enr.Course)
                .HasForeignKey(enr => enr.CourseId);

            // subject - course (1:m)
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Subject)
                .WithMany(s => s.Courses);

            // course - review (1:m)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Reviews)
                .WithOne (rev => rev.Course)
                .HasForeignKey (rev => rev.CourseId);

            // user - review (1:m)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(rev => rev.User)
                .HasForeignKey(rev => rev.UserId);

            // user - user testing (1:m)
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserTestings)
                .WithOne(ut => ut.User)
                .HasForeignKey(ut => ut.UserId);

            // test - user testing (1:m)
            modelBuilder.Entity<Test>()
                .HasMany(t => t.UserTestings)
                .WithOne(ut => ut.Test)
                .HasForeignKey(ut => ut.TestId);

            // course - lesson (1:m)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            // lesson - content (1:m)
            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Contents)
                .WithOne(ctn => ctn.Lesson)
                .HasForeignKey(ctn => new { ctn.LessonId, ctn.CourseId });

            // test - question (1:m)
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId);

            // question - answer (1:m)
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => new { a.QuestionId, a.TestId });

            // user testing - user answers (1:m)
            modelBuilder.Entity<UserTesting>()
                .HasMany(ut => ut.UserAnswers)
                .WithOne(ua => ua.UserTesting)
                .HasForeignKey(ua => ua.UserTestingId)
                .OnDelete(DeleteBehavior.NoAction);

            // answer - user answers (1:m)
            modelBuilder.Entity<Answer>()
                .HasMany(a => a.UserAnswers)
                .WithOne(ua => ua.Answer)
                .HasForeignKey(ua => new { ua.AnswerId, ua.QuestionId, ua.TestId })
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
