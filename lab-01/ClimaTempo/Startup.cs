using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClimaTempo
{
    public class Startup
    {
        /*
         - o ASPNET Core se encarrega de resolver a dependencia
         - usa-se interface para abstrair a implementação favorencedo o desacoplamento e troca da implementação
         - uma dependência é qualquer objeto exigido por outro objeto.

         fonte : https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1
        */

        // configuração é injetada para trabalharmos com confiugurações na aplicação
        // você quase certamente precisará acessar isso para configurar seus serviços, por isso faz sentido
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // adiciona os serviços necessários para usar controladores de API da Web e nada mais
            services.AddControllers();
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // verifica se estamos no ambiente de desenvolvimento
            if (env.IsDevelopment())
            {
                // página de erro no ambiente de desenvolvimento
                app.UseDeveloperExceptionPage();
            }

            // Middleware de redirecionamento de HTTPS para redirecionar solicitações HTTP para HTTPS.
            app.UseHttpsRedirection();


            // adiciona as configurações de roteamento ao conteiner de serviço
            // esse midleware verifica de onde vem e a requisição e decide qual endpoint pode executar
            // fonte: https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-3.1
            app.UseRouting();

            app.UseAuthorization();

            //  este midleware é reponsavel por configurar os endpoints e também por executalos
            // fonte: https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-3.1
            app.UseEndpoints(endpoints =>
            {
                /* 
                 definimos que sera nos requisições ser atendidas pelos controllers
                 os controladores da API são mapeados chamando endpoints.MapControllers (). 
                 Isso mapeia apenas controladores decorados com atributos de roteamento
                 */
                endpoints.MapControllers();
            });
        }
    }
}
