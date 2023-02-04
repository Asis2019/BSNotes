using BSNotes.Configuration;
using BSNotes.Managers;
using Zenject;

namespace BSNotes.Installers;

internal class BSNotesAppInstaller : Installer
{
    private readonly PluginConfig _config;

    public BSNotesAppInstaller(PluginConfig config)
    {
        _config = config;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(_config).AsSingle();
        Container.BindInterfacesAndSelfTo<NotesManager>().AsSingle();
    }
}