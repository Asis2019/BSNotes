using System;
using BeatSaberMarkupLanguage.Settings;
using Zenject;

namespace BSNotes.UI.Controllers;

internal class SettingsViewController : IInitializable, IDisposable
{
    public void Initialize()
    {
        BSMLSettings.instance.AddSettingsMenu(nameof(BSNotes), "BSNotes.UI.Views.SettingsView.bsml", this);
    }

    public void Dispose()
    {
        if (BSMLSettings.instance != null) BSMLSettings.instance.RemoveSettingsMenu(this);
    }
}