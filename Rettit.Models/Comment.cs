using System;
using System.ComponentModel.DataAnnotations;

namespace Rettit.Models
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime Posted { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
