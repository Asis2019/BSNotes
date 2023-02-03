using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using BSNotes.Configuration;
using BSNotes.Installers;
using IPALogger = IPA.Logging.Logger;

namespace BSNotes;

[Plugin(RuntimeOptions.DynamicInit)][NoEnableDisable]
public class Plugin
{
    private static Plugin Instance { get; set; } = null!;
    internal static IPALogger Log { get; set; } = null!;

    [Init]
    public Plugin(Zenjector zenjector, IPALogger logger, Config config)
    {
        Instance = this;
        Log = logger;
        Log.Info("BSNotes initialized.");

        zenjector.UseLogger(logger);
        zenjector.UseMetadataBinder<Plugin>();

        var pluginConfig = config.Generated<PluginConfig>();
        
        // This logic also goes for installing to Menu and Game. "Location." will give you a list of places to install to.
        zenjector.Install<BSNotesAppInstaller>(Location.App, pluginConfig);
        zenjector.Install<BSNotesMenuInstaller>(Location.Menu);
    }
}