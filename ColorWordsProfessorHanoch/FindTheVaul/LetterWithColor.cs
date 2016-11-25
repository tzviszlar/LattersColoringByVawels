using System;

namespace FindTheVaul
{
    public class LetterWithColor
    {
        private char _letter;
        private ConsoleColor _consoleColoring;
        private char _vowelAsciiCode;
        private string _vowelName;

        public char Letter
        {
            get { return _letter; }
            set { _letter = value; }
        }

        public ConsoleColor ConsoleColoring
        {
            get { return _consoleColoring; }
            set { _consoleColoring = value; }
        }

        public char VowelAsciiCode
        {
            get { return _vowelAsciiCode; }
            set { _vowelAsciiCode = value; }
        }

        public string VowelName
        {
            get { return _vowelName; }
            set { _vowelName = value; }
        }
    }
}