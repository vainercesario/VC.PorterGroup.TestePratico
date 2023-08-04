using VC.PorterGroup.TestePratico.Modulos;

namespace VC.PorterGroup.TestePratico;

public class Startup
{
    public IConfiguration Configuracao { get; }

    public Startup(IConfiguration configuration)
    {
        Configuracao = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .ConfigurarLog(Configuracao)
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