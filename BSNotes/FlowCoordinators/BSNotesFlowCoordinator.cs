using BeatSaberMarkupLanguage;
using BSNotes.UI.Controllers;
using HMUI;
using Zenject;

namespace BSNotes.FlowCoordinators;

internal class BSNotesFlowCoordinator : FlowCoordinator
{
    private MainFlowCoordinator _mainFlowCoordinator = null!;
    private MainViewController _mainViewController = null!;
    private NotesListViewController _notesListViewController = null!;

    [Inject]
    public void Inject(MainFlowCoordinator mainFlowCoordinator, MainViewController mainViewController,
        NotesListViewController notesListViewController)
    {
        _mainFlowCoordinator = mainFlowCoordinator;
        _mainViewController = mainViewController;
        _notesListViewController = notesListViewController;
    }

    protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
    {
        if (firstActivation)
        {
            SetTitle(nameof(BSNotes));
            showBackButton = true;

            ProvideInitialViewControllers(_mainViewController, _notesListViewController);
        }
    }

    protected override void BackButtonWasPressed(ViewController viewController)
    {
        _mainFlowCoordinator.DismissFlowCoordinator(this);
    }
}