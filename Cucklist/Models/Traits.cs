using System;
using System.Collections.Generic;

namespace Cucklist.Models
{
    public class Traits :IEquatable<Traits>, ITraits
    {
        private CuckRole cuckRole;
        private Sexuality sexuality;
        private int weight;
        private int height;
        private int age;
        private Ethnicity ethnicity;
        private Race race;
        private Color eyeColor;
        private Color hairColor;
        private Color skinColor;
        private BiologicalSex biologicalSex;

        public Traits()
        {
        }

        public CuckRole CuckRole { get => cuckRole; set => cuckRole = value; }
        public Sexuality Sexuality { get => sexuality; set => sexuality = value; }
        public int Weight { get => weight; set => weight = value; }
        public int Height { get => height; set => height = value; }
        public int Age { get => age; set => age = value; }
        public Ethnicity Ethnicity { get => ethnicity; set => ethnicity = value; }
        public Race Race { get => race; set => race = value; }
        public Color EyeColor { get => eyeColor; set => eyeColor = value; }
        public Color HairColor { get => hairColor; set => hairColor = value; }
        public Color SkinColor { get => skinColor; set => skinColor = value; }
        public BiologicalSex BiologicalSex { get => biologicalSex; set => biologicalSex = value; }

        public override bool Equals(object obj) => Equals(obj as Traits);
        public bool Equals(Traits other) => other != null && CuckRole == other.CuckRole && Sexuality == other.Sexuality && Weight == other.Weight && Height == other.Height && Age == other.Age && Ethnicity == other.Ethnicity && Race == other.Race && EyeColor == other.EyeColor && HairColor == other.HairColor && SkinColor == other.SkinColor && BiologicalSex == other.BiologicalSex;

        public override int GetHashCode()
        {
        var hashCode = 32417470;
        hashCode = hashCode * -1521134295 + CuckRole.GetHashCode();
        hashCode = hashCode * -1521134295 + Sexuality.GetHashCode();
        hashCode = hashCode * -1521134295 + Weight.GetHashCode();
        hashCode = hashCode * -1521134295 + Height.GetHashCode();
        hashCode = hashCode * -1521134295 + Age.GetHashCode();
        hashCode = hashCode * -1521134295 + Ethnicity.GetHashCode();
        hashCode = hashCode * -1521134295 + Race.GetHashCode();
        hashCode = hashCode * -1521134295 + EyeColor.GetHashCode();
        hashCode = hashCode * -1521134295 + HairColor.GetHashCode();
        hashCode = hashCode * -1521134295 + SkinColor.GetHashCode();
        hashCode = hashCode * -1521134295 + BiologicalSex.GetHashCode();
        return hashCode;
        }

        public static bool operator ==(Traits traits1,Traits traits2)
        {
        return EqualityComparer<Traits>.Default.Equals(traits1,traits2);
        }

        public static bool operator !=(Traits traits1,Traits traits2)
        {
        return !( traits1 == traits2 );
        }

        public override string ToString() => base.ToString();


    }

}


