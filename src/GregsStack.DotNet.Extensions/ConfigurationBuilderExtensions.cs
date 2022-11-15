using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;

namespace GregsStack.DotNet.Extensions;

/// <summary>
/// Created by David Fowler
/// https://gist.github.com/davidfowl/256525d319129df973839cd7245a1f87
/// </summary>
public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddConfigurationDefaults(this IConfigurationBuilder configurationBuilder, Dictionary<string, string?> defaults)
    {
        // Insert at 0 so that other configuration sources can override the defaults
        configurationBuilder.Sources.Insert(0, new MemoryConfigurationSource
        {
            InitialData = defaults
        });

        return configurationBuilder;
    }
}
