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
        public void BulkUpdate()
        {
            BulkUpdate();
        }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProduct { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<DiscountUser> DiscountUser { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<ItemCategory> ItemCategory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;database=AgriculturalMaterialDB;user=sa;pwd=3031998;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("BANNER");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BannerName)
                    .HasColumnName("Banner_Name")
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

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlImage)
                    .HasColumnName("Url_Image")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasColumnName("Category_Name")
                    .HasMaxLength(50);

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
            });

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.ToTable("CATEGORY_PRODUCT");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("Category_Id")
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

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryProduct)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CATEGORY_PRODUCT_CATEGORY");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CategoryProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CATEGORY_PRODUCT_PRODUCT");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .HasColumnName("City_Name")
                    .HasMaxLength(50);

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
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("DISCOUNT");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndAt)
                    .HasColumnName("End_At")
                    .HasColumnType("date");

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.StartAt)
                    .HasColumnName("Start_At")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlImage)
                    .HasColumnName("Url_Image")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiscountUser>(entity =>
            {
                entity.ToTable("DISCOUNT_USER");

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

                entity.Property(e => e.DiscountId)
                    .HasColumnName("Discount_Id")
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

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountUser)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_DISCOUNT_USER_DISCOUNT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DiscountUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DISCOUNT_USER_USER");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("DISTRICT");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CityId)
                    .IsRequired()
                    .HasColumnName("City_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictName)
                    .HasColumnName("District_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRICT_CITY");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.ToTable("ITEM_CATEGORY");

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

                entity.Property(e => e.ItemCategoryName)
                    .HasColumnName("Item_Category_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("LOCATION");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressName)
                    .HasColumnName("Address_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
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

                entity.Property(e => e.WardId)
                    .HasColumnName("Ward_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_LOCATION_USER");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName("FK_LOCATION_WARD");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDER");

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

                entity.Property(e => e.LocationId)
                    .HasColumnName("Location_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("Total_Price")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalQuantity).HasColumnName("Total_Quantity");

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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ORDER_USER");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("ORDER_DETAIL");

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

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ORDER_DETAIL_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ORDER_DETAIL_PRODUCT");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

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
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.IsNew).HasColumnName("Is_New");

                entity.Property(e => e.ItemCategoryId)
                    .HasColumnName("Item_Category_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MadeIn)
                    .HasColumnName("Made_In")
                    .HasMaxLength(50);

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProvidedBy)
                    .HasColumnName("Provided_By")
                    .HasMaxLength(50);

                entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TradeMark)
                    .HasColumnName("Trade_Mark")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlImage)
                    .HasColumnName("Url_Image")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WarrantyPeriod)
                    .HasColumnName("Warranty_Period")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

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

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AvatarPath)
                    .HasColumnName("Avatar_Path")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreateAt)
                    .HasColumnName("Create_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("Create_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasColumnName("Full_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.HashPassword)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaltPassword)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt)
                    .HasColumnName("Update_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("WARD");

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

                entity.Property(e => e.DistrictId)
                    .IsRequired()
                    .HasColumnName("District_Id")
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

                entity.Property(e => e.WardName)
                    .HasColumnName("Ward_Name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Ward)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WARD_DISTRICT");
            });
        }

    }
}
