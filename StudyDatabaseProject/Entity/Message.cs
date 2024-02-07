namespace StudyDatabaseProject.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}
