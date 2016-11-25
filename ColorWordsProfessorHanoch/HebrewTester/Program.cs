using FindTheVaul;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HebrewTester
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            var a = "דָדֻדִדֶדִדדדדדדֶדד".ToCharArray();
            var letterWithColorList = HebrewParser.GetListOfLetterWithColorFromCharArry(a);

            foreach (var letterWithColor in letterWithColorList)
            {
                Console.ForegroundColor = letterWithColor.ConsoleColoring;
                Console.Write(letterWithColor.Letter);
            }
            Console.ReadLine();
        }
    }
}
