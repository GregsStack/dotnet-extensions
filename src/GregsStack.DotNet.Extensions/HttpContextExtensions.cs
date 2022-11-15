using System.Net;
using Microsoft.AspNetCore.Http;

namespace GregsStack.DotNet.Extensions;

public static class HttpContextExtension
{
    private static readonly string[] defaultHeaders = { "CF-Connecting-IP", "X-Forwarded-For" };

    /// <summary>
    /// Get remote IP address, optionally allowing for header check for values of "CF-Connecting-IP" and "X-Forwarded-For".
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/>.</param>
    /// <param name="allowForwarded">Whether to allow header check.</param>
    /// <returns>The <see cref="IPAddress"/>.</returns>
    public static IPAddress GetRemoteIpAddress(this HttpContext context, bool allowForwarded = true)
        => GetRemoteIpAddress(context, defaultHeaders, allowForwarded);

    /// <summary>
    /// Get remote IP address, optionally allowing for header check.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/>.</param>
    /// <param name="headers">The headers to check for forwarded IP address information.</param>
    /// <param name="allowForwarded">Whether to allow header check.</param>
    /// <returns>The <see cref="IPAddress"/>.</returns>
    public static IPAddress GetRemoteIpAddress(this HttpContext context, IEnumerable<string> headers, bool allowForwarded = true)
    {
        if (allowForwarded)
        {
            var header = string.Empty;
            foreach (var key in headers)
            {
                header = context.Request.Headers[key].FirstOrDefault();
                if (!string.IsNullOrEmpty(header))
                {
                    break;
                }
            }

            if (IPAddress.TryParse(header ?? string.Empty, out var ip))
            {
                return ip;
            }
        }

        return context.Connection.RemoteIpAddress;
    }
}
