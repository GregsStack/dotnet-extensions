using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GregsStack.DotNet.Extensions;

/// <summary>
/// Extension Methods for loading configuration values.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Get configuration of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type of configuration.</typeparam>
    /// <param name="serviceCollection">Extending properties.</param>
    /// <returns>The <typeparamref name="T"/>.</returns>
    public static T GetConfiguration<T>(this IServiceCollection serviceCollection)
        where T : class, new() => serviceCollection.BuildServiceProvider().GetConfiguration<T>();

    /// <summary>
    /// Extension method for adding configuration section to <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="T">Type of configuration.</typeparam>
    /// <param name="serviceCollection">Extending properties.</param>
    /// <param name="sectionName">Name of configuration section that should be added to <see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddConfiguration<T>(this IServiceCollection serviceCollection, string sectionName) where T : class
    {
        var configuration = serviceCollection.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var section = configuration.GetSection(sectionName);
        return serviceCollection.AddConfiguration<T>(section);
    }

    /// <summary>
    /// Extension method for adding configuration section to <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="T">Type of configuration.</typeparam>
    /// <param name="serviceCollection">Extending properties.</param>
    /// <param name="configurationSection">Configuration section that should be added to <see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddConfiguration<T>(this IServiceCollection serviceCollection, IConfigurationSection configurationSection) where T : class =>
        serviceCollection.Configure<T>(configurationSection);
}
