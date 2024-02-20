using Amazon.Lambda.Core;
using AWSLambdaFunction.EntryPoint;
using Newtonsoft.Json.Linq;

namespace AWSLambdaFunction
{
    [AWSLambdaFunction.EntryPoint.Attributes.LambdaFunction(typeof(string), typeof(JToken))]
    public class LambdaFunction : ILambdaHandler<string, JToken>
    {
        public Func<string, ILambdaContext, JToken> Handler => Run;

        public JToken Run(string message, ILambdaContext context)
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