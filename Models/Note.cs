namespace TrialTask.Notes.Models;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public bool IsPrivate { get; set; }
}