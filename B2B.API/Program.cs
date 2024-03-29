using B2B.BusinessLayer.Abstract;
using B2B.BusinessLayer.Concrate;
using B2B.DataAccessLayer.Abstract;
using B2B.DataAccessLayer.Concrate;
using B2B.DataAccessLayer.EntityFramework;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<B2B_Context>();

//builder.Services.AddDbContext<B2B_Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>(
    opt =>
    {
        //google otp
        opt.SignIn.RequireConfirmedAccount = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 1;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireDigit = false;
        opt.User.RequireUniqueEmail = true;
        opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        // opt.SignIn.RequireConfirmedEmail = true;//mail doğrulaması olsun mu
    }
    )
    //.AddErrorDescriber<CustomerIdentityValidation>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<B2B_Context>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

 
builder.Services.AddScoped<IUserFavoriDAL, efUserFavoriRepository>();
builder.Services.AddScoped<IUserFavoriService, UserFavoriManager>();

builder.Services.AddScoped<IStockDAL, efStockRepository>();
builder.Services.AddScoped<IStockService, StockManager>();

builder.Services.AddScoped<IProductColorDAL, efProductColorRepository>();
builder.Services.AddScoped<IProductColorService, ProductColorManager>();

builder.Services.AddScoped<IDimensionsDAL, efDimensionsRepository>();
builder.Services.AddScoped<IDimensionsService, DimensionsManager>();

builder.Services.AddScoped<IProductSizeDAL, efProductSizeRepository>();
builder.Services.AddScoped<IProductSizeService, ProductSizeManager>();


builder.Services.AddScoped<IProductPriceDAL, efProductPriceRepository>();
builder.Services.AddScoped<IProductPriceService, ProductPriceManager>();

builder.Services.AddScoped<IContactDal, efContactRepository>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IContactMailRequestDal, efContactMailRequestRepository>();
builder.Services.AddScoped<IContactMailRequestService, ContactMailRequestManager>();

builder.Services.AddScoped<IBasketDAL, efBasketRepository>();
builder.Services.AddScoped<IBasketService, BasketManager>();

builder.Services.AddScoped<IColorDal, efColorRepository>();
builder.Services.AddScoped<IColorService, IColorManager>();


builder.Services.AddScoped<ICategoryDAL, efCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IChildSubCategoryDAL, efChildSubCategoryRepository>();
builder.Services.AddScoped<IChildSubCategoryService, ChildSubCategoryManager>();

builder.Services.AddScoped<IHomeSliderDAL, efHomeSliderRepository>();
builder.Services.AddScoped<IHomeSliderService, HomeSliderManager>();

builder.Services.AddScoped<IParentSubCategoryDAL, efParentSubCategoryRepository>();
builder.Services.AddScoped<IParentSubCategoryService, ParentSubCategoryManager>();

builder.Services.AddScoped<IProductDAL, efProductRepository>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IProductCategoriesDAL, efProductCategoriesRepository>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryManager>();


       


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.SetIsOriginAllowed((host) => true)
            //WithOrigins("https://localhost:44385/") 
                   .AllowCredentials()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowSpecificOrigin");
}
 
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
