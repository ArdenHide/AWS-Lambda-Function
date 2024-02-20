namespace AWSLambdaFunction.Lambda.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class LambdaFunctionAttribute : Attribute
{
    public Type RequestType { get; }
    public Type ResponseType { get; }

    public LambdaFunctionAttribute(Type requestType, Type responseType)
    {
        RequestType = requestType;
        ResponseType = responseType;
    }
}
