namespace TrialTask.Notes.Domain.Entities.Notes
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsPrivate { get; set; }
    }
}
