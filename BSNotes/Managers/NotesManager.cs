using System.Collections.Generic;
using System.IO;
using System.Linq;
using BSNotes.Model;
using IPA.Utilities;

namespace BSNotes.Managers;

internal class NotesManager
{
    private readonly List<Note> _notes = new();

    public NotesManager()
    {
        LoadNotes();
    }

    private void LoadNotes()
    {
        var directoryInfo = new DirectoryInfo(Path.Combine(UnityGame.UserDataPath, nameof(BSNotes)));
        var files = directoryInfo.GetFiles()
            .OrderBy(p => p.LastWriteTime)
            .Where(file => file.Extension == ".txt")
            .ToArray();

        foreach (var file in files)
            _notes.Add(new Note(file.Name.Replace(".txt", ""), file.OpenText().ReadToEnd()));
    }

    public List<Note> GetNotes()
    {
        return _notes;
    }
}