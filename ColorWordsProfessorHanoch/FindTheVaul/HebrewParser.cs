using System;
using System.Collections.Generic;

namespace FindTheVaul
{

    public static class HebrewParser
    {
        static HebrewCharTypes _lastChar;

        public static Tuple<string, int[]> GetVaulsFromWord(string word)
        {
            var theNumberPerEachVauls = new int[] {};
            
            
            var result = new Tuple<string, int[]>(word,theNumberPerEachVauls);

            return result;
        }

        public static List<LetterWithColor> GetListOfLetterWithColorFromCharArry(char[] text)
        {
            List<LetterWithColor> letterWithColorList = new List<LetterWithColor>();
            AddVowelToEachLetter(text, letterWithColorList);
            AddColorToEachLetter(letterWithColorList);
            return letterWithColorList;
        }

        private static void AddVowelToEachLetter(char[] text, List<LetterWithColor> letterWithColorList)
        {
            foreach (var c in text)
            {
                var mytext = FindTheVaul.HebrewCharsExtensions.GetHebrewCharType(c);
                if (mytext == HebrewCharTypes.Letter)
                {
                    if (_lastChar == HebrewCharTypes.Letter)
                    {
                        letterWithColorList[letterWithColorList.Count - 1].VowelAsciiCode = '1';
                    }
                    letterWithColorList.Add(new LetterWithColor() {Letter = c});
                }
                else if (mytext == HebrewCharTypes.Vowel)
                {
                    letterWithColorList[letterWithColorList.Count - 1].VowelAsciiCode = c;
                }
                else if (_lastChar == HebrewCharTypes.Letter)
                {
                    letterWithColorList.Add(new LetterWithColor() {Letter = c});
                }

                _lastChar = mytext;
            }
            if (_lastChar == HebrewCharTypes.Letter)
            {
                letterWithColorList[letterWithColorList.Count - 1].VowelAsciiCode = '1';
            }
        }

        private static void AddColorToEachLetter(List<LetterWithColor> letterWithColorList)
        {
            foreach (var letterWithColor in letterWithColorList)
            {
                var c = letterWithColor.VowelAsciiCode;

                if (c == 0x5b0)
                {
                    letterWithColor.ConsoleColoring = ConsoleColor.Green;
                }
                else if (c == 0x5b4)
                {
                    letterWithColor.ConsoleColoring = ConsoleColor.Red;
                }
                else if (c == 0x5b5 || c == 0x5b6)
                {
                    letterWithColor.ConsoleColoring = ConsoleColor.DarkGreen;
                }
                else if (c == 0x5b7 || c == 0x5b8)
                {
                    letterWithColor.ConsoleColoring = ConsoleColor.DarkGray;
                }
                else if (c == 0x05B9 || c == 0x05BA || c == 0x05BB)
                {
                    letterWithColor.ConsoleColoring = ConsoleColor.Cyan;
                }
                else if (letterWithColor.VowelAsciiCode == '1')
                {
                    letterWithColor.ConsoleColoring = ConsoleColor.Blue;
                }
                else
                {
                    letterWithColor.ConsoleColoring = ConsoleColor.White;
                }
            }
        }
    }
}
