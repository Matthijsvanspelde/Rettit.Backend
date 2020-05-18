using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rettit.Models
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime Posted { get; set; }
        [NotMapped]
        public long PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        [NotMapped]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
