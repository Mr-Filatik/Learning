namespace StudyDatabaseProject.Entity
{
    public class Reaction
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
