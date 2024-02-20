using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using AWSLambdaFunction.EntryPoint;
using AWSLambdaFunction.EntryPoint.Attributes;

namespace AWSLambdaFunction
{
    [LambdaEntryPoint(typeof(string), typeof(JToken))]
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