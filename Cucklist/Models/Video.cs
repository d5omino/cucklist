using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cucklist.Models
{
    public class Video
    {
        //Properties and Fields//
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ApplicationUser Owner { get; set; }

        //Constructors//
        public Video()
        {

        }

        public Video(string path)
        {
        Path = path;
        }

        //Methods//

    }
}
