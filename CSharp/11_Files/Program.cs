using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _11_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            // StreamWriter uses FileStream behinds the scenes
            using (StreamWriter sw1 = new StreamWriter("test.txt", append: false))
            {
                sw1.Write("!");
                sw1.WriteLine("ZX");
            }
            using(StreamReader sr1 = new StreamReader("test.txt"))
            {
                while (!sr1.EndOfStream)
                {
                    string line = sr1.ReadLine();
                }
            }

            using (StreamWriter sw3 = new StreamWriter("test3.txt", append: false))
            using (StreamWriter sw4 = new StreamWriter("test4.txt", append: false))
            {
                sw3.Write("!");
                sw4.WriteLine("ZX");
            }

            // File - static class. Better fits for small job with files
            // FIleInfo - ordinar class. Better fits for big jobs with files


            // BinaryWriter
            using (FileStream output = File.Create("data1.dat"))
            using(BinaryWriter writer = new BinaryWriter(output))
            {
                writer.Write(1);
                writer.Write(1.0);
                writer.Write(12m);
                writer.Write(true);
                writer.Write("sd");
                writer.Write('A');
                writer.Write(new byte[] { 1, 2, 3 });
                writer.Write(20f);
            }
            byte[] dataWritten1 = File.ReadAllBytes("data1.dat");
            foreach (var b in dataWritten1)
            {
                Console.Write("{0}/{0:x2} ", b);
            }
            using (FileStream input = File.OpenRead("data1.dat"))
            using(BinaryReader reader = new BinaryReader(input))
            {
                int a = reader.ReadInt32();
                double d = reader.ReadDouble();
                decimal dd = reader.ReadDecimal();
                bool b = reader.ReadBoolean();
                string s = reader.ReadString();
                char c = reader.ReadChar();
                byte[] bb = reader.ReadBytes(3);
                float f = reader.ReadSingle();
            }



                Console.ReadKey();
        }
    }
}
