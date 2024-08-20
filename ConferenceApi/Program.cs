using Microsoft.EntityFrameworkCore;

using Conference.Domain.Entities;
using Conference.Data;
using Conference.Service;
using ConferenceApi.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ConferenceContext>(options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ConferenceDatabase"),
            m => m.MigrationsAssembly("Conference.Domain")
        );
    });

builder.Services.AddScoped<ISpeakersRepository, SpeakersRepository>();
builder.Services.AddScoped<ISpeakersService, SpeakersService>();

builder.Services.AddScoped<IWorkshopsRepository, WorkshopsRepository>();

builder.Services.AddAutoMapper(typeof(SpeakerProfile));
builder.Services.AddAutoMapper(typeof(WorkshopProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("ConferenceApiCors", policy => {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("ConferenceApiCors");

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
