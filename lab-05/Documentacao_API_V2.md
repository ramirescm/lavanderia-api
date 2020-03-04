# Instalação do pacote

https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio

Adicione o gerador do Swagger à coleção de serviços no método Startup.ConfigureServices:

ConfigureServices

services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

No método Startup.Configure, habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger:

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

adicionar o router prefix e mostrar caso configurado para vazio já é resolvido a documentação

em launch.settings remover o valor de launchrurl e adicionar o router prefix
app.UseSwaggerUI(c =>
{
c.RoutePrefix = string.Empty;
});
