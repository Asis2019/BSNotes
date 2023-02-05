using System;
using BeatSaberMarkupLanguage.Attributes;
using BSNotes.Model;
using HMUI;

namespace BSNotes.UI.Components;

internal class NoteCell
{
    private readonly Note _note;
    private readonly Action<Note> _noteSelectedAction;
    private readonly Action<Note> _archiveAction;

    [UIComponent("file-name")] 
    protected readonly CurvedTextMeshPro _fileName = null!;

    public NoteCell(Note note, Action<Note> selectedAction, Action<Note> archiveAction)
    {
        _note = note;
        _noteSelectedAction = selectedAction;
        _archiveAction = archiveAction;
    }

    [UIAction("#post-parse")]
    protected void Parsed()
    {
        _fileName.text = _note.GetNoteTitle();
    }

    [UIAction("clicked-note")]
    protected void ClickedNote()
    {
        _noteSelectedAction?.Invoke(_note);
    }

    [UIAction("clicked-archive-button")]
    protected void ClickedArchiveButton()
    {
        _archiveAction?.Invoke(_note);
    }
}