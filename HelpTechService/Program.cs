using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Data;

using HelpTechService.Shared.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RoadCareService",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "RoadCare",
            Email = "roadcare@hotmail.com"
        }
    });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer", Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();

#region DataBase Configuration

builder.Services.AddTransient<IDbConnection>(db =>

    new SqlConnection(builder.Configuration
    .GetConnectionString("HelpTech"))
);
builder.Services.AddDbContext<HelpTechContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("HelpTech"));
});

#endregion

#region Dependencies Injections

#region Shared Context

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#endregion

var app = builder.Build();

app.UseCors(
    c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();