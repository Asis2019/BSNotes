using BSNotes.UI;
using Zenject;

namespace BSNotes.Installers;

internal class BSNotesMenuInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<BSNotesSettingsViewController>().AsSingle();
    }
}