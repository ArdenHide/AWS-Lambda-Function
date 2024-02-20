namespace AWSLambdaFunction.EntryPoint.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class LambdaEntryPointAttribute : Attribute
{
    public Type RequestType { get; }
    public Type ResponseType { get; }

    public LambdaEntryPointAttribute(Type requestType, Type responseType)
    {
        RequestType = requestType;
        ResponseType = responseType;
    }
}
