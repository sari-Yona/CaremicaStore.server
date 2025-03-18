using Dal_Repository.models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// הזרקות
builder.Services.AddScoped<IDal_Repository.IDalCategory, Dal_Repository.CategoryDal>();
builder.Services.AddScoped<IDal_Repository.IDalCompany, Dal_Repository.CompanyDal>();
builder.Services.AddScoped<IDal_Repository.IDalCustomer, Dal_Repository.CustomerDal>();
builder.Services.AddScoped<IDal_Repository.IDalProduct, Dal_Repository.ProductDal>();
builder.Services.AddScoped<IDal_Repository.IDalShopping, Dal_Repository.ShoppingDal>();
builder.Services.AddScoped<IDal_Repository.IDalShoppingDetail, Dal_Repository.SoppingDetailsDal>();

builder.Services.AddScoped<IBll_Services.IBllCategory, Bll_Services.CategoryBll>();
builder.Services.AddScoped<IBll_Services.IBllCompany, Bll_Services.CompanyBll>();
builder.Services.AddScoped<IBll_Services.IBllCustomer, Bll_Services.CustomerBll>();
builder.Services.AddScoped<IBll_Services.IBllProduct, Bll_Services.ProductBll>();
builder.Services.AddScoped<IBll_Services.IBllShopping, Bll_Services.ShoppingBll>();

builder.Services.AddDbContext<ProjectDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine));

// הגדרת מדיניות CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();
    });
});

var app = builder.Build();

// הפעלת CORS
app.UseCors("all");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
