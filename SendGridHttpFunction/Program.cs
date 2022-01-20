using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGridHttpFunction.Converters;
using System.Text.Json;

namespace SendGridHttpFunction
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(appBuilder =>
                {
                    appBuilder.ConfigureSystemTextJson();
                })
                .Build();

            host.Run();
        }
    }

    internal static class WorkerConfigurationExtensions
    {
        public static IFunctionsWorkerApplicationBuilder ConfigureSystemTextJson(this IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.Configure<JsonSerializerOptions>(jsonSerializerOptions =>
            {
                // Register the custom STJ converters to customize the serialization result.
                jsonSerializerOptions.Converters.Add(new SendGridMessageConverter());
                jsonSerializerOptions.Converters.Add(new PersonalizationConverter());
                jsonSerializerOptions.Converters.Add(new AttachmentConverter());
            });

            return builder;
        }
    }
}