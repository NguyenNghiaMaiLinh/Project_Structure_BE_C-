using Microsoft.EntityFrameworkCore;

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
                optionsBuilder.UseSqlServer("server=prc391dbserver.database.windows.net;database=dishydb;user=mailinh;pwd=Admin123;");
                //optionsBuilder.UseSqlServer("server=.;database=DISHYDB;user=sa;pwd=3031998;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Follower>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorId).IsUnicode(false);

                entity.Property(e => e.CreateBy).IsUnicode(false);

                entity.Property(e => e.FollowerId).IsUnicode(false);

                entity.Property(e => e.UpdateBy).IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.FollowerAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Follower_Register");

                entity.HasOne(d => d.FollowerNavigation)
                    .WithMany(p => p.FollowerFollowerNavigation)
                    .HasForeignKey(d => d.FollowerId)
                    .HasConstraintName("FK_Follower_Register1");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateBy).IsUnicode(false);

                entity.Property(e => e.RecipeId).IsUnicode(false);

                entity.Property(e => e.Unit).IsUnicode(false);

                entity.Property(e => e.UpdateBy).IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Material_Recipe");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateBy).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.UpdateBy).IsUnicode(false);
            });

            modelBuilder.Entity<RecipeRegister>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.RecipeId).IsUnicode(false);

                entity.Property(e => e.Saver).IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRegister)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_RecipeRegister_Recipe");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Avartar).IsUnicode(false);

                entity.Property(e => e.Cover).IsUnicode(false);

                entity.Property(e => e.DeviceToken).IsUnicode(false);

                entity.Property(e => e.HashPassword).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.SaltPassword).IsUnicode(false);
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateBy).IsUnicode(false);

                entity.Property(e => e.Image1).IsUnicode(false);

                entity.Property(e => e.Image2).IsUnicode(false);

                entity.Property(e => e.RecipeId).IsUnicode(false);

                entity.Property(e => e.UpdateBy).IsUnicode(false);

                entity.Property(e => e.Video).IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Step)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Step_Recipe");
            });
        }

    }
}
