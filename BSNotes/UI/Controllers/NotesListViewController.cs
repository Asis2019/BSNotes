using System;
using System.IO;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using BSNotes.Managers;
using BSNotes.Model;
using BSNotes.UI.Components;
using HMUI;
using Zenject;

namespace BSNotes.UI.Controllers;

[ViewDefinition("BSNotes.UI.Views.NotesListView.bsml")]
[HotReload(RelativePathToLayout = @"..\Views\NotesListView.bsml")]
internal class NotesListViewController : BSMLAutomaticViewController
{
    private MainViewController _mainViewController;
    private NotesManager _notesManager;
    private bool _didLoad;

    [Inject]
    public void Inject(NotesManager notesManager, MainViewController mainViewController)
    {
        _mainViewController = mainViewController;
        _notesManager = notesManager;
        _notesManager.RefreshNotes();
    }

    [UIComponent("notes-list")] 
    protected readonly CustomCellListTableData _notesList = null!;

    [UIComponent("no-notes-message")] 
    protected readonly CurvedTextMeshPro _noNotesMessage;

    [UIAction("refresh-list")]
    protected void RefreshList()
    {
        _didLoad = false;

        _mainViewController.ClearSelection();
        _notesManager.RefreshNotes();

        LoadNotes();
    }

    [UIAction("#post-parse")]
    protected void Parsed()
    {
        LoadNotes();
    }

    private void LoadNotes()
    {
        if (_didLoad)
            return;

        var notes = _notesManager.GetNotes();
        if (notes.Count <= 0)
        {
            ToggleList(false);
        }
        else
        {
            ToggleList(true);
            _notesList.data.Clear();

            foreach (var note in notes)
                _notesList.data.Add(new NoteCell(note, SelectNote, ArchiveNote));

            _notesList.tableView.ReloadData();
        }
        _didLoad = true;
    }

    private void SelectNote(Note note)
    {
        _mainViewController.OnNoteSelected(note);
    }

    private void ArchiveNote(Note note)
    {
        _mainViewController.ClearSelection();
        _notesManager.ArchiveNote(note);
        RefreshList();
    }

    private void ToggleList(bool isActive)
    {
        _notesList.gameObject.SetActive(isActive);
        _noNotesMessage.gameObject.SetActive(!isActive);
    }
}