using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rettit.Models
{
    public class Follow
    {
        [Key]
        public long Id { get; set; }
        [NotMapped]
        [Required]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }
        [NotMapped]
        public long SubForumId { get; set; }
        [ForeignKey("SubForumId")]
        public SubForum SubForum { get; set; }
    }
}
