using Hellang.Middleware.ProblemDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Text.Json.Serialization;
using TinyHelpers.Json.Serialization;
using ToolAPI.DataLayer;
using ToolsAPI.BusinessLayer.Mappers;
using ToolsAPI.BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseSerilog( (context, loggerConfiguration) =>
//{
//    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
//});
// builder.Host.ConfigureLogging(logging => { logging.AddNotepad(); });

builder.Services.AddProblemDetails(
    opzioni => 
        opzioni.Map<ApplicationException>(ex => new StatusCodeProblemDetails(
             StatusCodes.Status503ServiceUnavailable)
        {
            Title = "Servizio non disponibile"
        })
    );

builder.Services.AddLogging(x => x.AddNotepad());

// builder.Services.AddLogging(lb => lb.AddNotepad());

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opzioni =>
    {
        opzioni.JsonSerializerOptions.DefaultIgnoreCondition =
            JsonIgnoreCondition.WhenWritingNull;
        opzioni.JsonSerializerOptions.Converters.Add(new UtcDateTimeConverter());
        opzioni.JsonSerializerOptions.Converters
            .Add(new JsonStringEnumConverter());
    });


builder.Services.AddDbContext<IDataContext, MyDataContext>(
    opzioni => opzioni.UseSqlite("Data Source = demo.db")
);

builder.Services.AddAutoMapper(typeof(PersonMapper).Assembly);

// builder.Services.AddScoped<IPeopleService, PeopleService>();

builder.Services.Scan(scan => scan.FromAssemblyOf<PeopleService>()
.AddClasses(classes => classes.InExactNamespaceOf<PeopleService>())
.AsImplementedInterfaces()
.WithScopedLifetime());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseProblemDetails();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseSerilogRequestLogging();
app.UseAuthorization();

app.MapControllers();

app.Run();
