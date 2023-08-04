using VC.PorterGroup.TestePratico.Modulos;

namespace VC.PorterGroup.TestePratico;

public class Startup
{
    public IConfiguration configuracao { get; }

    public Startup(IConfiguration configuration)
    {
        configuracao = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .ConfigurarLog(configuracao)
            .ConfigurarSwagger()
            .AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.ConfigurarAmbienteDev();
        else
            app.ConfigurarAmbienteProducao();

        app.ConfiguracaoComum();
    }
}