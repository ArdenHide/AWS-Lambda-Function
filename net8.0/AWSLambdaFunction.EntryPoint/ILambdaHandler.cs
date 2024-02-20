using Amazon.Lambda.Core;

namespace AWSLambdaFunction.EntryPoint;

public interface ILambdaHandler<TRequest, TResponse>
{
    public Func<TRequest, ILambdaContext, TResponse> Handler { get; }
}