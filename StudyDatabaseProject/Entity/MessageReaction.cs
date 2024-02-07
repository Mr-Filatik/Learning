using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyDatabaseProject.Entity
{
    [PrimaryKey(nameof(MessageId), nameof(ReactionId))]
    public class MessageReaction
    {
        [ForeignKey(nameof(Message))]
        public int MessageId { get; set; }
        public Message Message { get; set; }

        [ForeignKey(nameof(Reaction))]
        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }
    }
}
