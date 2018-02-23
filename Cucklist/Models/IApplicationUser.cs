using System;

namespace Cucklist.Models
{
    public interface IApplicationUser
    {
        int Age { get; set; }
        Ethnicity Ethnicity { get; set; }
        Color EyeColor { get; set; }
        Color HairColor { get; set; }
        int Height { get; set; }
        Race Race { get; set; }
        CuckRole CuckRole { get; set; }
        BiologicalSex BiologicalSex { get; set; }
        Sexuality Sexuality { get; set; }
        Color SkinColor { get; set; }
        int Weight { get; set; }
        DateTime BirthDay { get; set; }

        bool Equals(Traits other);
    }
}