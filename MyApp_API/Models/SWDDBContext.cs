using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyApp_API.Models
{
    public partial class SWDDBContext : DbContext
    {
        public SWDDBContext()
        {
        }

        public SWDDBContext(DbContextOptions<SWDDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectMembers> ProjectMembers { get; set; }
        public virtual DbSet<TaskAssignee> TaskAssignee { get; set; }
        public virtual DbSet<TaskCategory> TaskCategory { get; set; }
        public virtual DbSet<TaskItem> TaskItem { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;database=SWDDB;user=sa;pwd=3031998;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("ACTIVITY");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityName)
                    .HasColumnName("Activity_Name")
                    .HasMaxLength(500);

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.TaskItemId)
                    .HasColumnName("Task_Item_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TaskItem)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.TaskItemId)
                    .HasConstraintName("FK_ACTIVITY_TASK_ITEM");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENT");

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

                entity.Property(e => e.Detail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.TaskItemId)
                    .HasColumnName("Task_Item_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TaskItem)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.TaskItemId)
                    .HasConstraintName("FK_COMMENT_TASK_ITEM");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_COMMENT_USER");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("PROJECT");

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

                entity.Property(e => e.ProjectName)
                    .HasColumnName("Project_Name")
                    .HasMaxLength(200);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectMembers>(entity =>
            {
                entity.ToTable("PROJECT_MEMBERS");

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

                entity.Property(e => e.ProjectId)
                    .HasColumnName("Project_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_PROJECT_MEMBERS_PROJECT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PROJECT_MEMBERS_USER");
            });

            modelBuilder.Entity<TaskAssignee>(entity =>
            {
                entity.ToTable("TASK_ASSIGNEE");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AssigneeId)
                    .HasColumnName("Assignee_Id")
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

                entity.Property(e => e.TaskItemId)
                    .HasColumnName("Task_Item_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.TaskAssignee)
                    .HasForeignKey(d => d.AssigneeId)
                    .HasConstraintName("FK_TASK_ASSIGNEE_USER");

                entity.HasOne(d => d.TaskItem)
                    .WithMany(p => p.TaskAssignee)
                    .HasForeignKey(d => d.TaskItemId)
                    .HasConstraintName("FK_TASK_ASSIGNEE_TASK_ITEM");
            });

            modelBuilder.Entity<TaskCategory>(entity =>
            {
                entity.ToTable("TASK_CATEGORY");

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

                entity.Property(e => e.ProjectId)
                    .HasColumnName("Project_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskCategoryName)
                    .HasColumnName("Task_Category_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TaskCategory)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_TASK_CATEGORY_PROJECT");
            });

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("TASK_ITEM");

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

                entity.Property(e => e.ExpiredDate)
                    .HasColumnName("Expired_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.TaskCategoryId)
                    .HasColumnName("Task_Category_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDescription)
                    .HasColumnName("Task_Description")
                    .HasMaxLength(500);

                entity.Property(e => e.TaskName)
                    .HasColumnName("Task_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TaskCategory)
                    .WithMany(p => p.TaskItem)
                    .HasForeignKey(d => d.TaskCategoryId)
                    .HasConstraintName("FK_TASK_ITEM_TASK_CATEGORY");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_USER_1");

                entity.ToTable("USERS");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AvatarPath)
                    .HasColumnName("Avatar_Path")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.HashPassword)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaltPassword)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });
        }
    }
}
