using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GregsStack.DotNet.Extensions;

/// <summary>
/// Extension Methods for loading configuration values.
/// </summary>
public static class ServiceProviderExtension
{
    /// <summary>
    /// Get configuration of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type of configuration.</typeparam>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/>.</param>
    /// <returns>The <typeparamref name="T"/>.</returns>
    public static T GetConfiguration<T>(this IServiceProvider serviceProvider)
        where T : class, new() => serviceProvider.GetRequiredService<IOptions<T>>().Value;
}
