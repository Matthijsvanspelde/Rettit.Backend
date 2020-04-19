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
        [ForeignKey("User")]
        public long UserId { get; set; }
        [ForeignKey("SubForum")]
        public long SubForumId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
    }
}
