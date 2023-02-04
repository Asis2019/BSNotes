namespace BSNotes.Model;

public class Note
{
    public readonly string fileName;
    public readonly string noteContent;

    public Note(string fileName, string noteContent)
    {
        this.fileName = fileName;
        this.noteContent = noteContent;
    }
}