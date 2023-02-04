using System.Threading.Tasks;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using BSNotes.Managers;
using BSNotes.UI.Components;
using Zenject;

namespace BSNotes.UI.Controllers;

[ViewDefinition("BSNotes.UI.Views.NotesListView.bsml")]
[HotReload(RelativePathToLayout = @"..\Views\NotesListView.bsml")]
internal class NotesListViewController : BSMLAutomaticViewController
{
    private NotesManager _notesManager;
    private bool _didLoad;

    [Inject]
    public void Inject(NotesManager notesManager)
    {
        _notesManager = notesManager;
    }

    [UIComponent("notes-list")] 
    protected readonly CustomCellListTableData _notesList = null!;

    [UIAction("#post-parse")]
    protected void Parsed()
    {
        _ = LoadNotes();
    }

    private async Task LoadNotes()
    {
        if (_didLoad)
            return;

        foreach (var note in _notesManager.GetNotes())
            _notesList.data.Add(new NoteCell(nameof(BSNotes), note));

        _notesList.tableView.ReloadData();
        _didLoad = true;
    }
}