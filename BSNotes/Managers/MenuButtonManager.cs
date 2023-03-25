using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using BSNotes.Configuration;
using BSNotes.FlowCoordinators;
using Zenject;

namespace BSNotes.Managers;

internal class MenuButtonManager : IInitializable, IDisposable
{
    private readonly MenuButton _menuButton;
    private readonly MainFlowCoordinator _mainFlowCoordinator;
    private readonly BSNotesFlowCoordinator _bsNotesFlowCoordinator;

    public MenuButtonManager(MainFlowCoordinator mainFlowCoordinator, BSNotesFlowCoordinator bsNotesFlowCoordinator)
    {
        _menuButton = new MenuButton(PluginConfig.Instance.Name, ShowFlowCoordinator);
        _mainFlowCoordinator = mainFlowCoordinator;
        _bsNotesFlowCoordinator = bsNotesFlowCoordinator;
    }

    public void Initialize()
    {
        if (!PluginConfig.Instance.Enabled) return; //Don't add menu button if mod is disabled 
        MenuButtons.instance.RegisterButton(_menuButton);
    }

    public void Dispose()
    {
        if (BSMLParser.IsSingletonAvailable && MenuButtons.IsSingletonAvailable)
            MenuButtons.instance.UnregisterButton(_menuButton);
    }

    private void ShowFlowCoordinator()
    {
        _mainFlowCoordinator.PresentFlowCoordinator(_bsNotesFlowCoordinator,
            animationDirection: HMUI.ViewController.AnimationDirection.Horizontal);
    }
}
