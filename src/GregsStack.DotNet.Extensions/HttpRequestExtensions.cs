using Microsoft.AspNetCore.Http;

namespace GregsStack.DotNet.Extensions;

public static class HttpRequestExtensions
{
    public static string GetDefaultUserLanguage(this HttpRequest request, string fallback = "en")
    {
        return request.GetUserLanguages().FirstOrDefault() ?? fallback;
    }

    public static IEnumerable<string> GetUserLanguages(this HttpRequest request)
    {
        return request.GetTypedHeaders()
            .AcceptLanguage
            ?.OrderByDescending(x => x.Quality ?? 1)
            .Select(x => x.Value.ToString()) ?? Enumerable.Empty<string>();
    }
}
