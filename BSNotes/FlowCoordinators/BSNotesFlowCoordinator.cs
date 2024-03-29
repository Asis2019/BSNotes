using BeatSaberMarkupLanguage;
using BSNotes.Configuration;
using BSNotes.UI.Controllers;
using HMUI;
using Zenject;

namespace BSNotes.FlowCoordinators;

internal class BSNotesFlowCoordinator : FlowCoordinator
{
    private MainFlowCoordinator _mainFlowCoordinator = null!;
    private MainViewController _mainViewController = null!;
    private NotesListViewController _notesListViewController = null!;
    private WViewController _wViewController = null!;

    [Inject]
    public void Inject(
        MainFlowCoordinator mainFlowCoordinator,
        MainViewController mainViewController,
        WViewController wViewController,
        NotesListViewController notesListViewController
    )
    {
        _mainFlowCoordinator = mainFlowCoordinator;
        _mainViewController = mainViewController;
        _notesListViewController = notesListViewController;
        _wViewController = wViewController;
    }

    protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
    {
        if (firstActivation)
        {
            SetTitle(PluginConfig.Instance.Name);
            showBackButton = true;

            //Check if the heathen setting is enabled or not
            if (PluginConfig.Instance.WPanelEnabled)
                ProvideInitialViewControllers(_mainViewController, _notesListViewController, _wViewController);
            else
                ProvideInitialViewControllers(_mainViewController, _notesListViewController);
        }
    }

    protected override void BackButtonWasPressed(ViewController viewController)
    {
        _mainFlowCoordinator.DismissFlowCoordinator(this);
    }
}
