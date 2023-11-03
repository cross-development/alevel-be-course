using System.Text.RegularExpressions;

namespace HW_6_3.Host.Helpers;

public sealed class KebabCaseRouteTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value) => value != null
        ? Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLower()
        : null;
}