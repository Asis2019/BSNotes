using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using BSNotes.Configuration;
using Zenject;

namespace BSNotes.UI.Controllers;

internal class SettingsViewController : IInitializable, IDisposable
{
    public void Initialize()
    {
        BSMLSettings.instance.AddSettingsMenu(PluginConfig.Instance.Name, "BSNotes.UI.Views.SettingsView.bsml", this);
    }

    public void Dispose()
    {
        if (BSMLSettings.instance != null) BSMLSettings.instance.RemoveSettingsMenu(this);
    }

    [UIValue("mod-enabled")]
    private bool EnableMod
    {
        get => PluginConfig.Instance.Enabled;
        set => PluginConfig.Instance.Enabled = value;
    }

    [UIValue("w-panel-enabled")]
    private bool EnableWPanel
    {
        get => PluginConfig.Instance.WPanelEnabled;
        set => PluginConfig.Instance.WPanelEnabled = value;
    }
}
