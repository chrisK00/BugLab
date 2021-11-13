namespace BugLab.Data.Entities
{
    public class Comment : AuditableEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
