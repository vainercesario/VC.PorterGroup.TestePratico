namespace VC.PorterGroup.TestePratico.Modulos;

public static class ConfigurarAmbiente
{
    public static IApplicationBuilder ConfigurarAmbienteDev(this IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VC.PorterGroup v1"));

        return app;
    }

    public static IApplicationBuilder ConfigurarAmbienteProducao(this IApplicationBuilder app)
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();

        return app;
    }

    public static IApplicationBuilder ConfiguracaoComum(this IApplicationBuilder app)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}