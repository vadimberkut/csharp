using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reverse string
            string str1 = "This string will be reversed!";
            string str1R = ReverseString(str1);
            Console.WriteLine("{0} - {1}", str1, str1R);
            Console.WriteLine();

            // Caesar cipher
            string str2 = "This string will be reversed!";
            string str2C = CaesarChiper(str2, 3);
            string str2DC = CaesarChiper(str2C, -3);
            Console.WriteLine("Caesar cipher");
            Console.WriteLine("{0} -> {1} -> {2}", str2, str2C, str2DC);
            Console.WriteLine();

            // Factorial
            int number1 = 5;
            long factorial1 = Factorial(number1);
            long factorial1R = FactorialR(number1);
            Console.WriteLine("Factorial");
            Console.WriteLine("{0}: {1} {2}", number1, factorial1, factorial1R);
            Console.WriteLine();

            // Fibo sequence
            Console.WriteLine("Fibo sequence");
            Console.WriteLine("{0}: {1}", 0, FiboSequence(0).ToArrayString());
            Console.WriteLine("{0}: {1}", 1, FiboSequence(1).ToArrayString());
            Console.WriteLine("{0}: {1}", 2, FiboSequence(2).ToArrayString());
            Console.WriteLine("{0}: {1}", 3, FiboSequence(3).ToArrayString());
            Console.WriteLine("{0}: {1}", 4, FiboSequence(4).ToArrayString());
            Console.WriteLine("{0}: {1}", 10, FiboSequence(10).ToArrayString());
            Console.WriteLine();



            Console.ReadKey();
        }

        static string ReverseString(string str)
        {
            // Array approach
            char[] chars = new char[str.Length];
            for (int i = str.Length - 1; i >= 0 ; i--)
            {
                chars[str.Length - 1 - i] = str[i];
            }
            return new string(chars);
        }

        static string CaesarChiper(string str, int shift)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                int code = (int)str[i];
                code = code + shift;
                sb.Append((char)code);
            }
            return sb.ToString();
        }


        static long Factorial(int number)
        {
            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
        static long FactorialR(int number)
        {
            if (number == 0) return 1;
            return number * Factorial(number - 1);
        }

        static int[] FiboSequence(int elementsCount)
        {
            int[] sequence = new int[elementsCount];
            for (int i = 0; i < elementsCount; i++)
            {
                if (i <= 1) sequence[i] = i;
                else sequence[i] = sequence[i - 2] + sequence[i - 1];
            }
            return sequence.ToArray();
        }
    }

    static class Extensions
    {
        public static string ToArrayString(this int[] source)
        {
            return String.Join(", ", source.Select(x => x.ToString()));
        }
    }
}
