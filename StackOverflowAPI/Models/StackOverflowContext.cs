using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StackOverflowAPI.Models
{
    public partial class StackOverflowContext : DbContext
    {

        public StackOverflowContext(DbContextOptions<StackOverflowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Question> Question { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-NFLSEOR\\SQLEXPRESS;Database=StackOverflow;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.AnswerId).HasColumnName("answer_id");

                entity.Property(e => e.Answer1)
                    .HasColumnName("answer")
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnName("question")
                    .IsUnicode(false);
            });
        }
    }
}
