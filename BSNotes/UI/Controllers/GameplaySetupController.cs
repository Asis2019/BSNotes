using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using BSNotes.Configuration;
using BSNotes.Managers;
using UnityEngine.UI;
using Zenject;

namespace BSNotes.UI.Controllers;

internal class GameplaySetupController : IInitializable, IDisposable, INotifyPropertyChanged
{
    private readonly NotesManager _notesManager;

    public event PropertyChangedEventHandler PropertyChanged;
    private int _noteIndex;

    public GameplaySetupController(NotesManager notesManager)
    {
        _notesManager = notesManager;
    }

    public void Initialize()
    {
        if (!PluginConfig.Instance.Enabled) return; //Don't button if mod is disabled

        _notesManager.RefreshNotes();
        GameplaySetup.instance.AddTab(PluginConfig.Instance.Name, "BSNotes.UI.Views.QuickNotesView.bsml", this);
    }

    public void Dispose()
    {
        if (GameplaySetup.IsSingletonAvailable) GameplaySetup.instance.RemoveTab(PluginConfig.Instance.Name);
    }

    private void ToggleButtons()
    {
        PrevButton.enabled = _noteIndex > 0;
        NextButton.enabled = _noteIndex < _notesManager.GetNoteCount() - 1;
    }

    private void DisplayNote()
    {
        var note = _notesManager.GetNote(_noteIndex);
        _title = note.GetNoteTitle();
        _content = note.GetNoteContent();

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteTitle)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteContent)));
    }

    #region ui

    private string _title = null!, _content = null!;

    [UIComponent("prev-button")] protected readonly Button PrevButton = null!;

    [UIComponent("next-button")] protected readonly Button NextButton = null!;

    [UIValue("title")]
    protected string NoteTitle
    {
        get => _title;
        set
        {
            _title = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteTitle)));
        }
    }

    [UIValue("content")]
    protected string NoteContent
    {
        get => _content;
        set
        {
            _content = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteContent)));
        }
    }

    [UIAction("prev-button-action")]
    protected void PreviousButtonAction()
    {
        _noteIndex -= 1;
        ToggleButtons();
        DisplayNote();
    }

    [UIAction("next-button-action")]
    protected void NextButtonAction()
    {
        _noteIndex += 1;
        ToggleButtons();
        DisplayNote();
    }

    [UIAction("#post-parse")]
    protected void Parsed()
    {
        ToggleButtons();
        DisplayNote();
    }

    #endregion
}
