using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyDatabaseProject.Entity
{
    [Table("NewUsers")]
    public class User2
    {
        [Key]
        public int UserIdentityFlag { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Column("OtherOther")]
        public string? Other { get; set; }

        [NotMapped]
        public int Count { get; set; }
    }
}
