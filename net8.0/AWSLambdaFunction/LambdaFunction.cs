using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;

namespace AWSLambdaFunction
{
    public static class LambdaFunction
    {
        private static async Task Main(string[] args)
        {
            await LambdaBootstrapBuilder.Create(FunctionHandler, new JsonSerializer())
                .Build()
                .RunAsync();
        }

        public static JToken FunctionHandler(object? message, ILambdaContext context)
        {
            var data = new JObject()
            {
                new JProperty("message", message)
            };

            context.Logger.Log($"{LogLevel.Debug}", $"{data}");

            return data;
        }
    }
}