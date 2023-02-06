using BSNotes.Managers;
using Zenject;

namespace BSNotes.Installers;

internal class BSNotesAppInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<NotesManager>().AsSingle();
    }
}