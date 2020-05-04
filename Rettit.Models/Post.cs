using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        public int SubForumId { get; set; }
        public SubForum SubForum { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
