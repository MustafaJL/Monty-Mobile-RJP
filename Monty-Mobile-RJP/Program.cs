using Application.Commands;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NpgsqlTypes;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using Serilog.Sinks.PostgreSQL.ColumnWriters;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
int RetryLimit = Convert.ToInt32(builder.Configuration.GetSection("RetryMechanism:RetryLimit").Value);
double TimeSpanInSeconds = Convert.ToInt64(builder.Configuration.GetSection("RetryMechanism:TimeSpanInSeconds").Value);
string connectionString = builder.Configuration.GetConnectionString("MontyRJP");

IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
{
    { "message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
    { "message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
    { "level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
    { "raise_date", new TimestampColumnWriter(NpgsqlDbType.TimestampTz) },
    { "exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
    { "properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
    { "props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
    { "machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
};

var logger = new LoggerConfiguration()
    .WriteTo.PostgreSQL(connectionString, "Logs", columnWriters,needAutoCreateTable: true)
    .MinimumLevel.Error()
    .CreateLogger();

builder.Services.AddLogging(x => x.AddSerilog(logger));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add new services to the container

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("MontyRJP"), builder =>
    {
        builder.EnableRetryOnFailure(RetryLimit, TimeSpan.FromSeconds(TimeSpanInSeconds), null);
    });
});

// add repo pattern
var repositoryAssembly = Assembly.GetAssembly(typeof(UserRepository)); 
builder.Services.AddRepositoriesFromAssembly(repositoryAssembly);

// add Mediatr
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterCommand).Assembly));


// Add Security
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer Scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
