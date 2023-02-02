using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Settings;
using BSNotes.Configuration;
using Zenject;

namespace BSNotes.UI
{
    internal class BSNotesViewController : IInitializable, IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // Use this to notify BSML of a UI Value change;

        // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name of the Method)));
        private readonly PluginConfig _config;

        public BSNotesViewController(PluginConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            BSMLSettings.instance.AddSettingsMenu("Name of your Mod", "Path.To.BSML.File.bsml", this);
        }

        public void Dispose()
        {
            if (BSMLSettings.instance != null) BSMLSettings.instance.RemoveSettingsMenu("Name of your Mod");
        }
    }
}