using BeatSaberMarkupLanguage;
using BSNotes.UI.Controllers;
using HMUI;
using Zenject;

namespace BSNotes.FlowCoordinators;

internal class BSNotesFlowCoordinator : FlowCoordinator
{
    private MainFlowCoordinator _mainFlowCoordinator = null!;
    private MainViewController _mainViewController;

    [Inject]
    public void Inject(MainFlowCoordinator mainFlowCoordinator, MainViewController mainViewController)
    {
        _mainFlowCoordinator = mainFlowCoordinator;
        _mainViewController = mainViewController;
    }

    protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
    {
        if (firstActivation)
        {
            SetTitle(nameof(BSNotes));
            showBackButton = true;

            ProvideInitialViewControllers(_mainViewController);
        }
    }

    protected override void BackButtonWasPressed(ViewController viewController)
    {
        _mainFlowCoordinator.DismissFlowCoordinator(this);
    }
}