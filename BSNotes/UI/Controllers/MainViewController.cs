using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;

namespace BSNotes.UI.Controllers;

[ViewDefinition("BSNotes.UI.Views.MainView.bsml")]
[HotReload(RelativePathToLayout = @"..\Views\MainView.bsml")]
internal class MainViewController : BSMLAutomaticViewController
{
}