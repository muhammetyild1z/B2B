using B2B.DataAccessLayer.Concrate;
using B2B.EntityLayer.Concrate;
using B2B.UI.ViewComponents.ProductDetailsSlider;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient<Product>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7268/api/Product/");
    client.DefaultRequestHeaders.Accept.Clear();
});

builder.Services.AddHttpClient<Productdimensions>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7268/api/Productdimensions/");
    client.DefaultRequestHeaders.Accept.Clear();
});

builder.Services.AddHttpClient<ProductStock>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7268/api/ProductStock/");
    client.DefaultRequestHeaders.Accept.Clear();
});


builder.Services.AddHttpClient<ContactMailRequest>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7268/api/ContactMailRequest/");
    client.DefaultRequestHeaders.Accept.Clear();
});


builder.Services.AddHttpClient<HomeSlider>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7268/api/HomeSlider/");
    client.DefaultRequestHeaders.Accept.Clear();
});

builder.Services.AddHttpClient<Contact>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7268/api/Contact/");
    client.DefaultRequestHeaders.Accept.Clear();
});

builder.Services.AddHttpClient<ProductColor>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7268/api/ProductColor/");
    client.DefaultRequestHeaders.Accept.Clear();
});

builder.Services.AddHttpClient<Basket>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7268/api/Basket/");
    client.DefaultRequestHeaders.Accept.Clear();
});



builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();
