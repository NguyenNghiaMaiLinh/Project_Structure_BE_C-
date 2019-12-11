using Microsoft.EntityFrameworkCore;
using MyApp.Core.Data.DTO;

namespace MyApp.Core.Data.Entity
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public void Commit()
        {
                SaveChanges();
        }

        #region Dto
        public virtual DbSet<WorkflowDto> WorkflowDto { get; set; }
        public virtual DbSet<CommentDto> CommentDto { get; set; }

        #endregion
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskAssignee> TaskAssignee { get; set; }
        public virtual DbSet<Workflow> Workflow { get; set; }
        public virtual DbSet<WorkflowMember> WorkflowMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=swdserverdb.database.windows.net;database=SWDDB;user=mailinh;pwd=Admin123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_USER_1");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AvatarPath)
                    .HasColumnName("Avatar_Path")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceToken)
                    .HasColumnName("Device_Token")
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

            modelBuilder.Entity<Comment>(entity =>
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

                entity.Property(e => e.Detail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("Image_Url")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.TaskId)
                    .HasColumnName("Task_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowMemberId)
                    .HasColumnName("Workflow_Member_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_Comment_Task");

                entity.HasOne(d => d.WorkflowMember)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.WorkflowMemberId)
                    .HasConstraintName("FK_Comment_WorkflowMember");
            });

            modelBuilder.Entity<Notification>(entity =>
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

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("Image_Url")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.IsRead).HasColumnName("Is_Read");

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.Receiver)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Topic).HasMaxLength(200);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
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

                entity.Property(e => e.IsMain).HasColumnName("Is_Main");

                entity.Property(e => e.PositionInWorkflow).HasColumnName("Position_In_Workflow");

                entity.Property(e => e.TaskMainId)
                    .HasColumnName("Task_Main_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

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

                entity.Property(e => e.WorkflowId)
                    .IsRequired()
                    .HasColumnName("Workflow_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TaskMain)
                    .WithMany(p => p.InverseTaskMain)
                    .HasForeignKey(d => d.TaskMainId)
                    .HasConstraintName("FK_Task_Task");

                entity.HasOne(d => d.Workflow)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.WorkflowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASK_PROJECT");
            });

            modelBuilder.Entity<TaskAssignee>(entity =>
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

                entity.Property(e => e.TaskId)
                    .HasColumnName("Task_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowMemberId)
                    .HasColumnName("Workflow_Member_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskAssignee)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_TaskAssignee_Task");

                entity.HasOne(d => d.WorkflowMember)
                    .WithMany(p => p.TaskAssignee)
                    .HasForeignKey(d => d.WorkflowMemberId)
                    .HasConstraintName("FK_TaskAssignee_WorkflowMember");
            });

            modelBuilder.Entity<Workflow>(entity =>
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

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.IsMain).HasColumnName("Is_Main");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowMainId)
                    .HasColumnName("Workflow_Main_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowName)
                    .HasColumnName("Workflow_Name")
                    .HasMaxLength(200);

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.Workflow)
                    .HasForeignKey(d => d.CreateBy)
                    .HasConstraintName("FK_PROJECT_USERS");

                entity.HasOne(d => d.WorkflowMain)
                    .WithMany(p => p.InverseWorkflowMain)
                    .HasForeignKey(d => d.WorkflowMainId)
                    .HasConstraintName("FK_Workflow_Workflow");
            });

            modelBuilder.Entity<WorkflowMember>(entity =>
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

                entity.Property(e => e.WorkflowMainId)
                    .HasColumnName("Workflow_Main_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkflowMember)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PROJECT_MEMBERS_USERS");

                entity.HasOne(d => d.WorkflowMain)
                    .WithMany(p => p.WorkflowMember)
                    .HasForeignKey(d => d.WorkflowMainId)
                    .HasConstraintName("FK_PROJECT_MEMBERS_PROJECT1");
            });
        }
    }

}
