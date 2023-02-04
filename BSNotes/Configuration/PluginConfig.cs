using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using IPA.Config.Stores.Attributes;
using SiraUtil.Converters;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace BSNotes.Configuration;

internal class PluginConfig
{
    public static PluginConfig Instance { get; set; } = null!;
    
    [NonNullable, UseConverter(typeof(VersionConverter))]
    public virtual Hive.Versioning.Version Version { get; set; } = new("0.0.0");
}