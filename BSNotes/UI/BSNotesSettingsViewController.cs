using System;
using BeatSaberMarkupLanguage.Settings;
using Zenject;

namespace BSNotes.UI;

internal class BSNotesSettingsViewController : IInitializable, IDisposable
{
    public void Initialize()
    {
        BSMLSettings.instance.AddSettingsMenu(nameof(BSNotes), "BSNotes.UI.Views.BSNotesSettingsView.bsml", this);
    }

    public void Dispose()
    {
        if (BSMLSettings.instance != null) BSMLSettings.instance.RemoveSettingsMenu(this);
    }
}