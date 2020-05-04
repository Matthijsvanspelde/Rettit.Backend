using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rettit.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public List<Post> Posts { get; set; }
        public List<SubForum> Subforums { get; set; }
        public List<Comment> Comments { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
