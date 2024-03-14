using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.Graph.Models.Security;



namespace B2B.DataAccessLayer.Concrate
{
    public class B2B_Context : IdentityDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-CH9SD0T; initial Catalog=b2bTest;Integrated Security=true ;TrustServerCertificate=True");

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ParentSubCategory> parentSubCategories { get; set; }
        public DbSet<ChildSubCategory> childSubCategories { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Stock> stock { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<HomeSlider> homeSliders { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<ContactMailRequest> contactMailRequests { get; set; }
        public DbSet<Dimensions> dimensions { get; set; }
        public DbSet<ProductPrice> productPrices { get; set; }
        public DbSet<ProductColor> productColors { get; set; }
        public DbSet<ProductSize> productSizes { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Dimensions>().HasKey(x => x.DimensionsID);

            modelBuilder.Entity<Product>().HasKey(x => x.ProductID);

            modelBuilder.Entity<Color>().HasKey(x => x.ColorID);

            modelBuilder.Entity<ProductColor>().HasKey(x => x.ProductColorID);
            modelBuilder.Entity<ProductColor>().HasOne(x=>x.color).WithMany().HasForeignKey(x=>x.ColorID);
            modelBuilder.Entity<ProductColor>().HasOne(x=>x.product).WithMany().HasForeignKey(x=>x.ProductID);

            modelBuilder.Entity<ProductSize>().HasKey(x => x.ProductSizeID);
            modelBuilder.Entity<ProductSize>().HasOne(x=>x.dimensions).WithMany().HasForeignKey(x=>x.DimensionsID);
            modelBuilder.Entity<ProductSize>().HasOne(x=>x.product).WithMany().HasForeignKey(x=>x.ProductID);
         


            modelBuilder.Entity<ProductPrice>().HasKey(x => x.PriceID);
            modelBuilder.Entity<ProductPrice>().HasOne(x => x.color).WithMany().HasForeignKey(x => x.ColorID);
            modelBuilder.Entity<ProductPrice>().HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductID);
            modelBuilder.Entity<ProductPrice>().HasOne(x => x.dimensions).WithMany().HasForeignKey(x => x.DimensionsID);

            modelBuilder.Entity<Stock>().HasKey(x => x.StockID);
            modelBuilder.Entity<Stock>().HasOne(x => x.color).WithMany().HasForeignKey(x => x.ColorID);
            modelBuilder.Entity<Stock>().HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductID);
            modelBuilder.Entity<Stock>().HasOne(x => x.dimensions).WithMany().HasForeignKey(x => x.DimensionsID);

            modelBuilder.Entity<ContactMailRequest>().HasKey(x => x.ContactMailRequestID);
            modelBuilder.Entity<Contact>().HasKey(x => x.ContactID);
            modelBuilder.Entity<HomeSlider>().HasKey(x => x.SliderID);
            modelBuilder.Entity<HomeSlider>().HasOne(x => x.product).WithMany().HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<Basket>().HasKey(x => x.BasketID);
            modelBuilder.Entity<Basket>().HasOne(x => x.appUser).WithMany().HasForeignKey(x => x.UserID);
            modelBuilder.Entity<Basket>().HasOne(x => x.productPrice).WithMany().HasForeignKey(x => x.PriceID);

            modelBuilder.Entity<Category>().HasKey(x => x.CategoryID);
            modelBuilder.Entity<ChildSubCategory>().HasKey(x => x.ChildSubCategoryID);
            modelBuilder.Entity<ParentSubCategory>().HasKey(x => x.ParentSubCategoryID);
            modelBuilder.Entity<ProductCategory>().HasKey(x => x.ParentSubCategoryID);

            modelBuilder.Entity<ProductCategory>().HasKey(x => x.ProductCategoryID);
            modelBuilder.Entity<ProductCategory>().HasOne(x => x.category).WithMany().HasForeignKey(x => x.CategoryID).IsRequired(true);
            modelBuilder.Entity<ProductCategory>().HasOne(x => x.parentSubCategory).WithMany().HasForeignKey(x => x.ParentSubCategoryID).IsRequired(false);
            modelBuilder.Entity<ProductCategory>().HasOne(x => x.ChildSubCategory).WithMany().HasForeignKey(x => x.ChildSubCategoryID).IsRequired(false);
            modelBuilder.Entity<ProductCategory>().HasOne(x => x.product).WithMany().HasForeignKey(x => x.ProductID).IsRequired(true);



            base.OnModelCreating(modelBuilder);
        }
    }
}
