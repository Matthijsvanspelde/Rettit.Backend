using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rettit.Models
{
    public class SubForum
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Standard")]
        public long UserId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public List<Rule> Rules { get; set; }
    }
}
