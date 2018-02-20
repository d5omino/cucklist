using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucklist.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        [Display(Name = "Post Type")]
        public PostType PostType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Url]
        [Required]
        public string Link { get; set; }

        public string UserId { get; set; }

        public string Owner { get; set; }




    }
}
