using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BSNotes.Configuration;
using Hive.Versioning;

namespace BSNotes.UI.Controllers;

[ViewDefinition("BSNotes.UI.Views.WView.bsml")]
[HotReload(RelativePathToLayout = @"..\Views\WView.bsml")]
public class WViewController : BSMLAutomaticViewController
{
    private readonly Version _version;

    public WViewController()
    {
        _version = PluginConfig.Instance.Version;
    }

    [UIValue("version")] protected string Version => $"v{_version}";
}