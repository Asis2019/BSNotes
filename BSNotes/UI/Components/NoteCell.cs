using BeatSaberMarkupLanguage.Attributes;
using BSNotes.Model;
using HMUI;

namespace BSNotes.UI.Components;

internal class NoteCell
{
    public readonly Note note;

    [UIComponent("file-name")] protected readonly CurvedTextMeshPro _fileName = null!;

    [UIComponent("note-content")] protected readonly CurvedTextMeshPro _noteContent = null!;

    public NoteCell(Note note)
    {
        this.note = note;
    }

    [UIAction("#post-parse")]
    protected void Parsed()
    {
        _fileName.text = note.fileName;
        _noteContent.text = note.noteContent;
    }

    [UIAction("clicked-create-button")]
    protected void ClickedCreateButton()
    {
        Plugin.Log.Info("BSNotes: Button Clicked");
    }
}