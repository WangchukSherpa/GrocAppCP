using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjWork.Data;
using ProjWork.Helper;
using ProjWork.Repo;
using ProjWork.Repo.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(options =>
{
options.JsonSerializerOptions.PropertyNamingPolicy = null;
options.JsonSerializerOptions.DictionaryKeyPolicy = null;

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // This option helps with handling circular references during serialization
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ProductFilterHelper>();
builder.Services.AddScoped<IBasketRepo, BasketRepo>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection String not found")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
