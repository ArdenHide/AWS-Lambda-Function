using Amazon.Lambda.Core;

namespace AWSLambdaFunction.Lambda;

public interface ILambdaHandler<TRequest, TResponse>
{
    public Func<TRequest, ILambdaContext, TResponse> Handler { get; }
}