using BSNotes.FlowCoordinators;
using BSNotes.Managers;
using BSNotes.UI.Controllers;
using Zenject;

namespace BSNotes.Installers;

internal class BSNotesMenuInstaller : Installer
{
    public override void InstallBindings()
    {
        //Bind button that lives in the main menu
        Container.BindInterfacesTo<MenuButtonManager>().AsSingle();

        //Bind controllers
        Container.Bind<MainViewController>().FromNewComponentAsViewController().AsSingle();

        //Bind settings view controller
        Container.BindInterfacesTo<SettingsViewController>().AsSingle();

        //Bind main flow coordinator
        Container.Bind<BSNotesFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
    }
}