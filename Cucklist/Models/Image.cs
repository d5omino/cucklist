using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucklist.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ImageId { get; set; }
        public long Size { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        [Required]
        [Url]
        public string PathToImage { get; set; }
        [Required]
        [StringLength(250)]
        public string FileName { get; set; }
        public string Name { get; set; }
        public long ImageData { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}