using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cucklist.Models
{
    public class Image :IDisposable
    {
        //Fields and Properties//
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public ApplicationUser ImageOwner { get; set; }
        void IDisposable.Dispose() { }
        public void GetData() { }

        public Image()
        {

        }

        public Image(string path)
        {

        string RecordPath = path;

        }

    }
}
