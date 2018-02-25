using System;

using Microsoft.AspNetCore.Identity;

namespace Cucklist.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser :IdentityUser, ITraits, IApplicationUser
    {




        public int Age { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public Color EyeColor { get; set; }
        public Color HairColor { get; set; }
        public int Height { get; set; }
        public Race Race { get; set; }
        public CuckRole CuckRole { get; set; }
        public BiologicalSex BiologicalSex { get; set; }
        public Sexuality Sexuality { get; set; }
        public Color SkinColor { get; set; }
        public int Weight { get; set; }
        public DateTime BirthDay { get; set; }

        public byte[] AvatarImage { get; set; }





        public bool Equals(Traits other)
        {
        throw new NotImplementedException();
        }
    }
}
