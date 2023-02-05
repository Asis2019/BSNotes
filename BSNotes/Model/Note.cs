using System.IO;

namespace BSNotes.Model;

public class Note
{
    private readonly FileInfo _noteFileInfo;
    private readonly string _noteContent;

    public Note(FileInfo noteFileInfo, string noteContent)
    {
        _noteFileInfo = noteFileInfo;
        _noteContent = noteContent;
    }

    public string GetNoteTitle()
    {
        return _noteFileInfo.Name.Replace(".txt", "");
    }

    public string GetNoteContent()
    {
        return _noteContent;
    }

    public string GetFilePath()
    {
        return _noteFileInfo.ToString();
    }

    public string GetFileName()
    {
        return _noteFileInfo.Name;
    }
}