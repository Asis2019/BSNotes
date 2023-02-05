using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BSNotes.Model;
using Zenject;

namespace BSNotes.UI.Controllers;

[ViewDefinition("BSNotes.UI.Views.MainView.bsml")]
[HotReload(RelativePathToLayout = @"..\Views\MainView.bsml")]
internal class MainViewController : BSMLAutomaticViewController
{
    private string _title = null!, _content = null!;

    [Inject]
    public void Inject()
    {
        ClearSelection();
    }

    [UIValue("title")]
    protected string NoteTitle
    {
        get => _title;
        set { _title = value; NotifyPropertyChanged(); }
    }
        
    [UIValue("content")]
    protected string NoteContent
    {
        get => _content;
        set { _content = value; NotifyPropertyChanged(); }
    }

    public void OnNoteSelected(Note note)
    {
        NoteTitle = note.GetNoteTitle();
        NoteContent = note.GetNoteContent();
    }

    public void ClearSelection()
    {
        NoteTitle = "Select a note for viewing";
        NoteContent = "";
    }
}