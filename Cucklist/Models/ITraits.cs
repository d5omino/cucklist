namespace Cucklist.Models
{
    public interface ITraits
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

        bool Equals(object obj);
        bool Equals(Traits other);
        int GetHashCode();
        string ToString();
    }
}