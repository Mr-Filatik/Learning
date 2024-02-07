namespace StudyDatabaseProject.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Message> Messages { get; set; }
    }

    public class UserK
    {
        public int Id { get; set; }
        public int UserKeyId { get; set; }
        public UserKey? UserKey { get; set; }
    }

    public class UserKey
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public UserK User { get; set; }
    }
}
