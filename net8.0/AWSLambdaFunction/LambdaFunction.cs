using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambdaFunction;

public class LambdaFunction
{
    public JToken Run(object? message, ILambdaContext context)
    {
        var data = new JObject()
        {
            new JProperty("message", message)
        };

        context.Logger.Log($"{LogLevel.Debug}", $"{data}");

        return data;
    }
}