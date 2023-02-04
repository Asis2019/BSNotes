using System.IO;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using BSNotes.Configuration;
using BSNotes.Installers;
using IPA.Loader;
using IPA.Utilities;
using IPALogger = IPA.Logging.Logger;

namespace BSNotes;

[Plugin(RuntimeOptions.DynamicInit)][NoEnableDisable]
public class Plugin
{
    private static Plugin Instance { get; set; } = null!;
    internal static IPALogger Log { get; private set; } = null!;

    [Init]
    public Plugin(Zenjector zenjector, IPALogger logger, Config config, PluginMetadata metadata)
    {
        Instance = this;
        Log = logger;
        Log.Info("BSNotes initialized.");
        
        var folderPath = Path.Combine(UnityGame.UserDataPath, nameof(BSNotes));
        Directory.CreateDirectory(folderPath);

        zenjector.UseLogger(logger);
        zenjector.UseMetadataBinder<Plugin>();

        var pluginConfig = config.Generated<PluginConfig>();
        pluginConfig.Version = metadata.HVersion;
        
        // This logic also goes for installing to Menu and Game. "Location." will give you a list of places to install to.
        zenjector.Install<BSNotesAppInstaller>(Location.App, pluginConfig);
        zenjector.Install<BSNotesMenuInstaller>(Location.Menu);
    }
}