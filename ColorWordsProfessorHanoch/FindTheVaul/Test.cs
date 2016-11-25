namespace FindTheVaul
{
    using System.Linq;
    using System.Collections.Generic;

    public static class HebrewCharsExtensions
    {
        public static bool IsHebrew(this char c)
        {
            return IsHebrew(c, HebrewCharTypes.All);
        }

        public static bool IsHebrew(this char c, HebrewCharTypes charTypes)
        {
            foreach (var kv in Map.Where(ct => charTypes.HasFlag(ct.Key)))
            {
                var locMap = kv.Value;
                for (int i = 0; i <= locMap.GetUpperBound(0); i++)
                    if (c >= locMap[i, 0] && c <= locMap[i, 1]) return true;
            }
            return false;
        }

        public static HebrewCharTypes GetHebrewCharType(this char c)
        {
            foreach (var kv in Map)
            {
                var locMap = kv.Value;
                for (int i = 0; i <= locMap.GetUpperBound(0); i++)
                    if (c >= locMap[i, 0] && c <= locMap[i, 1]) return kv.Key;
            }
            return HebrewCharTypes.None;
        }

        public static IEnumerable<char> GetHebChars()
        {
            return GetHebChars2(HebrewCharTypes.All);
        }

        private static IEnumerable<char> GetHebChars2(HebrewCharTypes charTypes)
        {
            int iii = 1;
            foreach (var kv in Map.Where(ct => charTypes.HasFlag(ct.Key)))
            {
                var locMap = kv.Value;
                for (int i = 0; i <= locMap.GetUpperBound(0); i++)
                {
                    var start = locMap[i, 0];
                    var end = locMap[i, 1];
                    foreach (var ch in Enumerable.Range(start, end - start + 1))
                        yield return (char)ch;
                }
            }
        }

        private static readonly Dictionary<HebrewCharTypes, int[,]> Map = new Dictionary<HebrewCharTypes, int[,]>
    {
       {HebrewCharTypes.Letter,   new int[,] { { 0x05d0, 0x05ea } } },
       {HebrewCharTypes.Vowel,    new int[,] { { 0x05b0, 0x05b9 }, { 0x05bb, 0x05c4 }, { 0xfb2a, 0xfb36 }, { 0xfb38, 0xfb3c }, { 0xfb3e, 0xfb3e }, { 0xfb40, 0xfb41 }, { 0xfb43, 0xfb44 }, { 0xfb46, 0xfb4e} } },
       {HebrewCharTypes.Biblical, new int[,] { { 0x0591, 0x05a1 }, { 0x05a3, 0x05af }, { 0xfb1e, 0xfb1e }, { 0xfb4f, 0xfb4f } } },
       {HebrewCharTypes.Yiddish,  new int[,] { { 0x05f0, 0x05f2 }, { 0xfb1f, 0xfb1f } } },
       {HebrewCharTypes.Special,  new int[,] { { 0x05f3, 0x05f4 }, { 0xfb20, 0xfb29 } } }
    };

    }

    [System.Flags]
    public enum HebrewCharTypes
    {
        /// <summary>
        /// Not a Hebrew character.
        /// </summary>
        None = 0,
        /// <summary>
        /// Alef to Tav.
        /// </summary>
        Letter = 1,
        /// <summary>
        /// Qamats to Hataf Segol.
        /// </summary>
        Vowel = 2,
        /// <summary>
        /// Kadma Munah Pashta etc.
        /// </summary>
        Biblical = 4,
        /// <summary>
        /// Double Yod etc.
        /// </summary>
        Yiddish = 8,
        /// <summary>
        /// Other special characters (wide chars and more).
        /// </summary>
        Special = 16,
        All = Letter | Vowel | Biblical | Yiddish | Special
    }
}
