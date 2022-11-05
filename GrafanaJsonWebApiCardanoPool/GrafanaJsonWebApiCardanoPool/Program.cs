using GrafanaJsonWebApiCardanoPool.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

DiContainerConfig.ConfigureSettings(builder.Services, builder.Configuration);
DiContainerConfig.ConfigureCoreAppContainer(builder.Services);

builder.Host.ConfigureLogging(logging =>
{
    logging.AddLog4Net("log4net.ñonfig");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
