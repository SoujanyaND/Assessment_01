using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_serialization
{
    class Utilities
    {
        public static int GetInteger( string question)
        {
            Console.WriteLine(question);
            return int.Parse(Console.ReadLine());
        }
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        public static double GetDouble(string question)
        {
            Console.WriteLine(question);
            return double .Parse(Console.ReadLine());
        }
        public static long GetLong(string question)
        {
            Console.WriteLine(question);
            return long.Parse(Console.ReadLine());
        }
        public static float GetFloat(string question)
        {
            Console.WriteLine(question);
            return float.Parse(Console.ReadLine());
        }
        public static DateTime GetDateTime(string question)
        {
            Console.WriteLine(question);
            return DateTime.Parse(Console.ReadLine());
        }
    }
}
