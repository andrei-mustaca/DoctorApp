using DoctorApp.Application;
using DoctorApp.Application.Interfaces;
using DoctorApp.Application.Services;
using DoctorApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ISpecializationService,SpecializationService>();
builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IPoliclinicService, PoliclinicService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.Run();

