using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using Hive.Versioning;
using IPA.Loader;
using SiraUtil.Zenject;
using Zenject;

namespace BSNotes.UI.Controllers;

[ViewDefinition("BSNotes.UI.Views.MainView.bsml")]
[HotReload(RelativePathToLayout = @"..\Views\MainView.bsml")]
internal class MainViewController : BSMLAutomaticViewController
{
    private Version _version = null!;

    [Inject]
    public void Construct(UBinder<Plugin, PluginMetadata> metadataBinder)
    {
        _version = metadataBinder.Value.HVersion;
    }

    [UIValue("version")] protected string Version => $"v{_version}";
}