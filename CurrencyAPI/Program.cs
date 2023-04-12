using Business.Services.Abstract;
using Business.Services.Concrete;
using DataAccess.Services.Abstract;
using DataAccess.Services.Concrete;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);


//Serilog Configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Debug()
    .CreateLogger();
//Serilog IOC
builder.Host.UseSerilog(Log.Logger);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICurrencyService,CurrencyManager>();
builder.Services.AddSingleton<ICurrencyDal,DpCurrencyDal>();




var app = builder.Build();

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
