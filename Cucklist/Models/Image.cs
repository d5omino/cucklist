using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cucklist.Models
{
    public class Image
    {
        //Fields and Properties//
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ApplicationUser Owner { get; set; }


        public Image()
        {

        }

        public Image(string path) => Path = path;


    }
}
