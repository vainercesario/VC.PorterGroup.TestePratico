namespace Microsoft.Extensions.DependencyInjection;

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
            .AdicionarServicos()
            .AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.ConfigurarAmbienteDev();
        }
        else
        {
            app.ConfigurarAmbienteProducao();
        }

        app.ConfiguracaoComum();
    }
}