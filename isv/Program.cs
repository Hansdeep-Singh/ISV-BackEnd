using Microsoft.EntityFrameworkCore;
using isv.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var AllowAll = "AllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAll,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source=Hansdeep;Initial Catalog=isv;Integrated Security=True"));
var app = builder.Build();

app.UseCors(AllowAll);
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
