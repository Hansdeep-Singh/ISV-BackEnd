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


//builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source=Hansdeep;Initial Catalog=isv;Integrated Security=True"));
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source = SQL5107.site4now.net; Initial Catalog = db_9ac37b_isv; User Id = db_9ac37b_isv_admin; Password = hansdeep@isv12345"));


var app = builder.Build();

app.UseCors(AllowAll);
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
