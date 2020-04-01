using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rettit.Models
{
    public class Rule
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Standard")]
        public long SubForumId { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
    }
}
