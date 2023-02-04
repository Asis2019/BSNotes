using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using Hive.Versioning;

namespace BSNotes.UI.Controllers;

[ViewDefinition("BSNotes.UI.Views.MainView.bsml")]
[HotReload(RelativePathToLayout = @"..\Views\MainView.bsml")]
internal class MainViewController : BSMLAutomaticViewController
{
    private Version _version = null!;


    public void Construct()
    {
        _version = new Version("0.0.0.0");
    }

    [UIValue("version")] protected string Version => $"v{_version}";
}