using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace B2B.DataAccessLayer.Concrate
{
    public class B2B_Context:IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-CH9SD0T;initial catalog=b2btest; integrated Security=true; TrustServerCertificate=True") ;
        }
      

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ParentSubCategory> parentSubCategories { get; set; }
        public DbSet<ChildSubCategory> childSubCategories { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<ProductColor> productColors { get; set; }
        public DbSet<Basket> baskets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>().HasKey(x => x.BasketID);
            modelBuilder.Entity<Basket>().HasOne(x=>x.product).WithMany().HasForeignKey(x=>x.ProductID);
            modelBuilder.Entity<Basket>().HasOne(x=>x.appUser).WithMany().HasForeignKey(x=>x.UserID);

            modelBuilder.Entity<ProductColor>().HasKey(x => x.ProductColorID);
            modelBuilder.Entity<ProductColor>().HasOne(x => x.product).WithMany().HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<Product>().HasKey(x => x.Product_ID);
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryID);
            modelBuilder.Entity<ChildSubCategory>().HasKey(x => x.ChildSubCategoryID);
            modelBuilder.Entity<ParentSubCategory>().HasKey(x => x.ParentSubCategoryID);
            modelBuilder.Entity<ProductCategory>().HasKey(x => x.ParentSubCategoryID);

            modelBuilder.Entity<ProductCategory>().HasKey(x => x.ProductCategoryID);
            modelBuilder.Entity<ProductCategory>().HasOne(x=>x.category).WithMany().HasForeignKey(x=>x.CategoryID).IsRequired(true);
            modelBuilder.Entity<ProductCategory>().HasOne(x=>x.parentSubCategory).WithMany().HasForeignKey(x=>x.ParentSubCategoryID).IsRequired(false);
            modelBuilder.Entity<ProductCategory>().HasOne(x=>x.ChildSubCategory).WithMany().HasForeignKey(x=>x.ChildSubCategoryID).IsRequired(false);
            modelBuilder.Entity<ProductCategory>().HasOne(x=>x.product).WithMany().HasForeignKey(x=>x.ProductID).IsRequired(true);


           
           

            base.OnModelCreating(modelBuilder);
        }
    }
}
