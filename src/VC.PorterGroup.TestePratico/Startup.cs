using Microsoft.OpenApi.Models;
using Serilog;

namespace VC.PorterGroup.TestePratico;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigurarLog(services);

        services.AddControllers();

        ConfigurarSwagger(services);
    }

    private void ConfigurarLog(IServiceCollection services)
    {
        services.AddSingleton(Configuration);

        Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

        services.AddLogging(logBuilder =>
        {
            logBuilder.ClearProviders();
            logBuilder.AddSerilog(dispose: true);
        });
    }

    private void ConfigurarSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "VC.PorterGroup", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            ConfigurarAmbienteDev(app);
        }
        else
        {
            ConfigurarAmbienteProducao(app);
        }

        ConfiguracaoComum(app);
    }

    private void ConfigurarAmbienteDev(IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VC.PorterGroup v1"));
    }

    private void ConfigurarAmbienteProducao(IApplicationBuilder app)
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    private void ConfiguracaoComum(IApplicationBuilder app)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}