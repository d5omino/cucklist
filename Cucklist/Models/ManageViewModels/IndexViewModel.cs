using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace Cucklist.Models.ManageViewModels
{
    public class IndexViewModel
    {




        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        public CuckRole CuckRole { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public Color EyeColor { get; set; }
        public Color HairColor { get; set; }
        public Color SkinColor { get; set; }
        public Race Race { get; set; }
        public Sexuality Sexuality { get; set; }
        public BiologicalSex BiologicalSex { get; set; }
        public DateTime Birthday { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public IFormFile AvatarImage { get; set; }






    }
}
