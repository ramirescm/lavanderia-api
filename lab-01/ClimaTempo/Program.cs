using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ClimaTempo
{
    public class Program
    {
        // ponto de entrada do aplicativo
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    /* 
                        O Kestrel é um servidor Web multiplataforma para o ASP.NET Core. O Kestrel é o servidor Web 
                        que está incluído por padrão em modelos de projeto do ASP.NET Core.

                        fonte: https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.1
                    */

                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        // aqui podemos configurar o kestrel especificando outras configurações
                    }).UseStartup<Startup>();
                });
    }
}
