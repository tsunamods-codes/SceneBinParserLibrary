using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SceneParser;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            Parser parser = new Parser(true);
            parser.LoadSceneBin(@"D:\Games\FINAL FANTASY VII\data\battle\scene.bin");
            Console.ReadLine();
        }
    }
}
