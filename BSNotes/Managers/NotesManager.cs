using System.Collections.Generic;

namespace BSNotes.Managers;

internal class NotesManager
{
    private readonly List<string> _notes = new();

    public NotesManager()
    {
        _notes.Add("A note item");
        _notes.Add("A second note item");
    }

    public List<string> GetNotes()
    {
        return _notes;
    }
}