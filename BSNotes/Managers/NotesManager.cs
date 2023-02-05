using System.Collections.Generic;
using System.IO;
using System.Linq;
using BSNotes.Model;
using IPA.Utilities;

namespace BSNotes.Managers;

internal class NotesManager
{
    private readonly List<Note> _notes = new();

    public void RefreshNotes()
    {
        _notes.Clear();
        LoadNotes();
    }

    public void ArchiveNote(Note note)
    {
        var directory = Path.Combine(UnityGame.UserDataPath, nameof(BSNotes));
        var destinationFile = Path.Combine(Path.Combine(directory, "Archive"), note.GetFileName());
        
        Plugin.Log.Info($"File to move: {note.GetFileName()}, FilePath: {note.GetFilePath()}, FileDest: {destinationFile}");
        
        File.Move(note.GetFilePath(), destinationFile);
    }

    public List<Note> GetNotes()
    {
        return _notes;
    }

    private void LoadNotes()
    {
        var directoryInfo = new DirectoryInfo(Path.Combine(UnityGame.UserDataPath, nameof(BSNotes)));
        var files = directoryInfo.GetFiles()
            .OrderByDescending(p => p.LastWriteTime)
            .Where(file => file.Extension == ".txt")
            .ToArray();

        foreach (var file in files)
            _notes.Add(new Note(file, file.OpenText().ReadToEnd()));
    }
}