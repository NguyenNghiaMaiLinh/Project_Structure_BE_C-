using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyApp_API.Models
{
    public partial class DISHYDBContext : DbContext
    {
        public DISHYDBContext()
        {
        }

        public DISHYDBContext(DbContextOptions<DISHYDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Active> Active { get; set; }
        public virtual DbSet<Follower> Follower { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeRegister> RecipeRegister { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<Step> Step { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;database=DISHYDB;user=sa;pwd=3031998;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Active>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Active)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Active_Recipe");
            });

            modelBuilder.Entity<Follower>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FollowerId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.FollowerAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Follower_Register3");

                entity.HasOne(d => d.FollowerNavigation)
                    .WithMany(p => p.FollowerFollowerNavigation)
                    .HasForeignKey(d => d.FollowerId)
                    .HasConstraintName("FK_Follower_Register2");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Material_Recipe");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecipeRegister>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(10);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Saver)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRegister)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_RecipeRegister_Recipe");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Avartar)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cover)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname).HasMaxLength(100);

                entity.Property(e => e.HashPassword)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaltPassword)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Image1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Image2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Video)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Step)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Step_Recipe");
            });
        }
    }
}
