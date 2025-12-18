using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Manager_mobile_Api.Data
{
    public class AppDbContext : DbContext
    {
        // User Management
        public DbSet<LevelUser> LevelUser { get; set; }
        public DbSet<UserKey> UserKey { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserRoleAssignment> UserRoleAssignment { get; set; }

        // Business Entities
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Employee> Employee { get; set; }

        // Warehouse & Products
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<StorageLocation> StorageLocation { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        // Transactions
        public DbSet<GoodsReceipt> GoodsReceipt { get; set; }
        public DbSet<GoodsReceiptDetail> GoodsReceiptDetail { get; set; }
        public DbSet<GoodsIssue> GoodsIssue { get; set; }
        public DbSet<GoodsIssueDetail> GoodsIssueDetail { get; set; }
        public DbSet<SalesTransaction> SalesTransaction { get; set; }
        public DbSet<UserCompleteInfoView> UserCompleteInfoViews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique constraints
            modelBuilder.Entity<UserKey>()
                .HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductCode).IsUnique();
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.CustomerCode).IsUnique();
            // Get Views Data
            modelBuilder.Entity<UserCompleteInfoView>()
            .HasNoKey()
            .ToView("vw_UserCompleteInfo");
        }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }       
    }
}