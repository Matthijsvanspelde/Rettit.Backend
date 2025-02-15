﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rettit.Models
{
    public class SubForum
    {
        [Key]
        public long Id { get; set; }
        public List<Post> Posts { get; set; }
        
        public string Name { get; set; }
        public string About { get; set; } 
        public string Rule1 { get; set; }
        public string Rule2 { get; set; }
        public string Rule3 { get; set; }
        [NotMapped]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
