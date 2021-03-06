using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Omt.Api
{

    /*
        Implementacoes nesta pratica:
        1. Uso de options: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-3.1, 
                https://www.c-sharpcorner.com/article/asp-net-core-how-to-acces-configurations-using-options-pattern/
        2. Uso de DDD
        3. Uso de HttpClientFactory: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.1
        4. Devido tratamento de exceção: https://github.com/gabrielschade/Tango
        5. Uso de DI
        6. Uso de Swagger: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
        7. Uso de ProduceResponseType
        8. Testes de unidade e/ou de integracao: https://medium.com/@jozimar5/testes-de-unidade-e-integra%C3%A7%C3%A3o-com-net-core-e-xunit-fad7c18a29a1
        9. Documentacao minima
        10. Bom uso de HttpCodes nos retornos de apis
        11. Retornos de apis sao Task<ICollection> genericos
        12. Uso de docker no azure: https://medium.com/@gbbigardi/utilizando-containers-docker-para-apis-em-asp-net-core-com-web-app-on-containers-afb12fbeb366

        https://drive.google.com/file/d/15NBGbmQO7FMnJDbR8Mm_QrJDSyw-5E5ss/view
    */
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
