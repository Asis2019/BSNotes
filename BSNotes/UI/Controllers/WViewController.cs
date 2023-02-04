using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using Hive.Versioning;
using IPA.Loader;
using SiraUtil.Zenject;
using Zenject;

namespace BSNotes.UI.Controllers;

[ViewDefinition("BSNotes.UI.Views.WView.bsml")]
[HotReload(RelativePathToLayout = @"..\Views\WView.bsml")]
public class WViewController : BSMLAutomaticViewController
{
    private Version _version = null!;

    [Inject]
    public void Inject(UBinder<Plugin, PluginMetadata> metadataBinder)
    {
        _version = metadataBinder.Value.HVersion;
    }

    [UIValue("version")] protected string Version => $"v{_version}";
}