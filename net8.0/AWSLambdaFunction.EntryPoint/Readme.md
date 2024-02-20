# AWSLambdaFunction.EntryPoint

The `AWSLambdaFunction.EntryPoint` NuGet package simplifies the creation of AWS Lambda functions in .NET 8.0 by allowing developers to abstract away the boilerplate `Main` method and focus on the business logic.
This package introduces a declarative approach to define Lambda entry points using attributes and interfaces.

## Defining Your Lambda Function

- **Implement the `ILambdaHandler<TRequest, TResponse>` Interface**: This interface requires you to define a `Handler` property, which is a function that takes a request of type `TRequest` and an `ILambdaContext`, and returns a response of type `TResponse`.
- **Annotate Your Class with `LambdaFunctionAttribute`**: Specify the request and response types for your Lambda function by annotating your class with the `LambdaFunctionAttribute`.

## Example
Here's a simple example of a Lambda function that accepts a string request and returns a JSON object:

```csharp
using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;
using AWSLambdaFunction.EntryPoint;
using AWSLambdaFunction.EntryPoint.Attributes;

[LambdaFunction(typeof(string), typeof(JToken))]
public class LambdaFunction : ILambdaHandler<string, JToken>
{
    public Func<string, ILambdaContext, JToken> Handler => Run;

    private JToken Run(string message, ILambdaContext context)
    {
        var data = new JObject
        {
            ["message"] = message
        };

        context.Logger.LogLine($"Received message: {message}");
        return data;
    }
}
```
