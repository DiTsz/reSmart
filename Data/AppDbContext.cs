using reSmart.Models;

namespace reSmart.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserTesting> UserTestings { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // primary keys

            modelBuilder.Entity<User>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.IdRole);

            modelBuilder.Entity<Enrollment>()
                .HasKey(enr => enr.IdEnrollment);

            modelBuilder.Entity<Review>()
                .HasKey(rev => rev.IdReview);

            modelBuilder.Entity<Subject>()
                .HasKey(sub => sub.IdSubject);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.IdCourse);

            modelBuilder.Entity<Lesson>()
                .HasKey(l => new { l.IdLesson, l.CourseId });

            modelBuilder.Entity<Content>()
                .HasKey(ctn => new { ctn.IdContent, ctn.LessonId, ctn.CourseId });

            modelBuilder.Entity<Test>()
                .HasKey(t => t.IdTest);

            modelBuilder.Entity<Question>()
                .HasKey(q => new { q.IdQuestion, q.TestId });

            modelBuilder.Entity<Answer>()
                .HasKey(ans => new { ans.IdAnswer, ans.QuestionId, ans.TestId });

            modelBuilder.Entity<UserTesting>()
                .HasKey(ut => ut.IdTesting);

            modelBuilder.Entity<UserAnswers>()
                .HasKey(ua => new { ua.IdUserAnswers, ua.UserTestingId });

            // user - role (m:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // user - review (1:m)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(rev => rev.User)
                .HasForeignKey(rev => rev.UserId);

            // user - enrollment (1:m)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Enrollments)
                .WithOne(enr => enr.User)
                .HasForeignKey(enr => enr.UserId);

            // user - testing (1:m)
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserTestings)
                .WithOne(ut => ut.User)
                .HasForeignKey(ut => ut.UserId);

            // course - enrollment (1:m)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(enr => enr.Course)
                .HasForeignKey(enr => enr.CourseId);

            // course - review (1:m)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Reviews)
                .WithOne(rev => rev.Course)
                .HasForeignKey(rev => rev.CourseId);

            // course - lesson (1:m)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            // subject - course (1:m)
            modelBuilder.Entity<Subject>()
                .HasMany(sub => sub.Courses)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId);

            // lesson - content (1:m)
            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Contents)
                .WithOne(ctn => ctn.Lesson)
                .HasForeignKey(ctn => new { ctn.CourseId, ctn.LessonId });

            // test - user testing (1:m)
            modelBuilder.Entity<Test>()
                .HasMany(t => t.UserTestings)
                .WithOne(ut => ut.Test)
                .HasForeignKey(ut => ut.TestId);

            // test - question (1:m)
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => new { q.IdQuestion, q.TestId });

            // question - answer (1:m)
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(ans => ans.Question)
                .HasForeignKey(ans => new { ans.IdAnswer, ans.QuestionId, ans.TestId });

            // user testing - user answers (1:m)
            modelBuilder.Entity<UserTesting>()
                .HasMany(ut => ut.UserAnswers)
                .WithOne(ua => ua.UserTesting)
                .HasForeignKey(ua => new { ua.IdUserAnswers, ua.UserTestingId });

            // answer - user answer (1:m)
            modelBuilder.Entity<Answer>()
                .HasMany(a => a.UserAnswers)
                .WithOne(ua => ua.Answer)
                .HasForeignKey(ua => new { ua.IdUserAnswers, ua.AnswerId });
        }
    }
}
