using BeatSaberMarkupLanguage.Attributes;
using HMUI;

namespace BSNotes.UI.Components;

internal class NoteCell
{
    public readonly string fileName, noteContent;

    [UIComponent("file-name")] protected readonly CurvedTextMeshPro _fileName = null!;

    [UIComponent("note-content")] protected readonly CurvedTextMeshPro _noteContent = null!;

    public NoteCell(string fileName, string noteContent)
    {
        this.fileName = fileName;
        this.noteContent = noteContent;
    }

    [UIAction("#post-parse")]
    protected void Parsed()
    {
        _fileName.text = fileName;
        _noteContent.text = noteContent;
    }

    [UIAction("clicked-create-button")]
    protected void ClickedCreateButton()
    {
        Plugin.Log.Info("BSNotes: Button Clicked");
    }
}