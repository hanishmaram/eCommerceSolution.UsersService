using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddInfrastructure();
builder.Services.AddCore();


// Add Controllers
builder.Services.AddControllers().AddJsonOptions(options => { 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


// Build the web application
var app = builder.Build();


app.UseExceptionHandlingMiddleware();

// Routing
//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
