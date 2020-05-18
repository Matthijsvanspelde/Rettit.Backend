using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rettit.Models
{
    public class Post
    {
        [Key]
        public long Id { get; set; }
        public List<Comment> Comments { get; set; }
        
        public string Title { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        [NotMapped]
        public long SubForumId { get; set; }
        [ForeignKey("SubForumId")]
        public SubForum SubForum { get; set; }
        [NotMapped]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
