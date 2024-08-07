using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Text;

using HelpTechService.IAM.Application.Internal.CommandServices;
using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Application.Internal.QueryServices;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Consumer;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;
using HelpTechService.IAM.Domain.Services.CriminalRecord;
using HelpTechService.IAM.Domain.Services.Specialty;
using HelpTechService.IAM.Domain.Services.Technical;
using HelpTechService.IAM.Domain.Services.TechnicalCredential;
using HelpTechService.IAM.Interfaces.ACL;
using HelpTechService.IAM.Interfaces.ACL.Services;
using HelpTechService.IAM.Infrastructure.Hashing.Argon2id;
using HelpTechService.IAM.Infrastructure.Persistence.EFC.Repositories;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using HelpTechService.IAM.Infrastructure.Request;
using HelpTechService.IAM.Infrastructure.Token.JWT.Configuration;
using HelpTechService.IAM.Infrastructure.Token.JWT.Services;

using HelpTechService.Interaction.Infrastructure.Socket;

using HelpTechService.Location.Application.Internal.QueryServices;
using HelpTechService.Location.Domain.Repositories;
using HelpTechService.Location.Domain.Services.Department;
using HelpTechService.Location.Domain.Services.District;
using HelpTechService.Location.Interfaces.ACL;
using HelpTechService.Location.Interfaces.ACL.Services;
using HelpTechService.Location.Infrastructure.Persistence.EFC.Repositories;

using HelpTechService.Report.Application.Internal.CommandServices;
using HelpTechService.Report.Application.Internal.QueryServices;
using HelpTechService.Report.Domain.Repositories;
using HelpTechService.Report.Domain.Services.Complaint;
using HelpTechService.Report.Domain.Services.TypeComplaint;
using HelpTechService.Report.Infrastructure.Persistence.EFC.Repositories;

using HelpTechService.Shared.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

using HelpTechService.Statistic.Application.Internal.QueryServices;
using HelpTechService.Statistic.Domain.Repositories;
using HelpTechService.Statistic.Domain.Services;
using HelpTechService.Statistic.Infrastructure.Persistence.Dapper.Repositories;

using HelpTechService.Subscription.Application.Internal.CommandServices;
using HelpTechService.Subscription.Application.Internal.QueryServices;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Subscription.Domain.Services.Contract;
using HelpTechService.Subscription.Domain.Services.Membership;
using HelpTechService.Subscription.Interfaces.ACL;
using HelpTechService.Subscription.Interfaces.ACL.Services;
using HelpTechService.Subscription.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HelpTechService",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "HelpTech",
            Email = "helptech@hotmail.com"
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

#region JWT Configuration

var jwtSettings = builder.Configuration.GetSection("JWT_SETTINGS");
builder.Services.Configure<JwtSettings>(jwtSettings);

var secretKey = jwtSettings["JWT_SECRET_KEY"];
var audience = jwtSettings["JWT_AUDIENCE_TOKEN"];
var issuer = jwtSettings["JWT_ISSUER_TOKEN"];
var securityKey = !string.IsNullOrEmpty(secretKey) ?
    new SymmetricSecurityKey
    (Encoding.Default.GetBytes(secretKey)) :
    throw new ArgumentNullException
    (nameof(secretKey), "Secret key is null or empty!");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = securityKey,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddTransient<TokenValidationHandler>();

builder.Services.AddAuthorization();

#endregion

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

#region IAM Context

builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<ISpecialtyQueryService, SpecialtyQueryService>();

builder.Services.AddScoped<ITechnicalRepository, TechnicalRepository>();
builder.Services.AddScoped<ITechnicalCommandService, TechnicalCommandService>();
builder.Services.AddScoped<ITechnicalQueryService, TechnicalQueryService>();

builder.Services.AddScoped<IConsumerRepository, ConsumerRepository>();
builder.Services.AddScoped<IConsumerCommandService, ConsumerCommandService>();
builder.Services.AddScoped<IConsumerQueryService, ConsumerQueryService>();

builder.Services.AddScoped<ITechnicalCredentialRepository, TechnicalCredentialRepository>();
builder.Services.AddScoped<ITechnicalCredentialCommandService, TechnicalCredentialCommandService>();
builder.Services.AddScoped<ITechnicalCredentialQueryService, TechnicalCredentialQueryService>();

builder.Services.AddScoped<IConsumerCredentialRepository, ConsumerCredentialRepository>();
builder.Services.AddScoped<IConsumerCredentialCommandService, ConsumerCredentialCommandService>();
builder.Services.AddScoped<IConsumerCredentialQueryService, ConsumerCredentialQueryService>();

builder.Services.AddScoped<ICriminalRecordRepository, CriminalRecordRepository>();
builder.Services.AddScoped<ICriminalRecordCommandService, CriminalRecordCommandService>();
builder.Services.AddScoped<ICriminalRecordQueryService, CriminalRecordQueryService>();

builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IReniecService, ReniecService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

builder.Services.AddTransient<HelpTechService.IAM.Application.Internal.OutboundServices.ACL.ExternalLocationService>();
builder.Services.AddTransient<HelpTechService.IAM.Application.Internal.OutboundServices.ACL.ExternalSubscriptionService>();

#endregion

#region Location Context

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentQueryService, DepartmentQueryService>();

builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictQueryService, DistrictQueryService>();

builder.Services.AddScoped<ILocationContextFacade, LocationContextFacade>();

#endregion

#region Report Context

builder.Services.AddScoped<ITypeComplaintRepository, TypeComplaintRepository>();
builder.Services.AddScoped<ITypeComplaintQueryService, TypeComplaintQueryService>();

builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();
builder.Services.AddScoped<IComplaintCommandService, ComplaintCommandService>();
builder.Services.AddScoped<IComplaintQueryService, ComplaintQueryService>();

#endregion

#region Shared Context

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region Statistic Context

builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
builder.Services.AddScoped<IStatisticQueryService, StatisticQueryService>();

#endregion

#region Subscription Context

builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipQueryService, MembershipQueryService>();

builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IContractCommandService, ContractCommandService>();
builder.Services.AddScoped<IContractQueryService, ContractQueryService>();

builder.Services.AddScoped<ISubscriptionContextFacade, SubscriptionContextFacade>();

builder.Services.AddTransient<HelpTechService.Subscription.Application.Internal.OutboundServices.ACL.ExternalIamService>();

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

#region WebSocket Configuration

var webSocketOptions = new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromMinutes(2),
};

app.UseWebSockets(webSocketOptions);

var webSocketHandler = new WebSocketHandler();

app.Map("/chat", webSocketHandler.HandleWebSocketAsync);

#endregion

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();