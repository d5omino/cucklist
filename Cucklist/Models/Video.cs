using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucklist.Models
{
    public class Video
    {
        //Properties and Fields//
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ApplicationUser Owner { get; set; }

        //Constructors//
        public Video()
        {

        }

        public Video(string path) => Path = path;



    }
}
