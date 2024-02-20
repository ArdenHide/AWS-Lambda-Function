using System.Reflection;
using Amazon.Lambda.RuntimeSupport;
using AWSLambdaFunction.EntryPoint.Attributes;

namespace AWSLambdaFunction.EntryPoint;

public static class EntryPoint
{
    public static async Task Main(string[] args)
    {
        var type = Assembly.GetExecutingAssembly().GetTypes().ToList()
            .Find(t => t.GetCustomAttributes(typeof(LambdaEntryPointAttribute), false).Length > 0);
        if (type == null) return;

        var attribute = type.GetCustomAttribute<LambdaEntryPointAttribute>();
        if (attribute == null) return;

        var method = typeof(EntryPoint).GetMethod(nameof(RunLambdaAsync), BindingFlags.NonPublic | BindingFlags.Static)
            ?.MakeGenericMethod(attribute.RequestType, attribute.ResponseType);
        if (method != null)
        {
            await (Task)method.Invoke(null, new object[] { type });
        }
    }

    private static async Task RunLambdaAsync<TRequest, TResponse>(Type lambdaEntryPointType)
    {
        var instance = Activator.CreateInstance(lambdaEntryPointType) as ILambdaHandler<TRequest, TResponse>;
        if (instance == null) throw new InvalidOperationException($"Failed to create an instance of {lambdaEntryPointType}.");

        await LambdaBootstrapBuilder.Create(instance.Handler, new Amazon.Lambda.Serialization.Json.JsonSerializer())
            .Build()
            .RunAsync();
    }
}