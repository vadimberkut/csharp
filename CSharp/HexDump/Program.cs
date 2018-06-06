using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HexDump
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 0x20;
            string hex = String.Format("{0:x2}", j);
            // Console.WriteLine(j); // diplays 32
            // Console.WriteLine(hex); // 20

            // Create test binary file
            string testText = "Hello! #$_Asdfg. 123, 12.3 true cc";
            File.WriteAllText("test.txt", testText);

            using (FileStream output = File.Create("test.dat"))
            using (BinaryWriter writer = new BinaryWriter(output))
            {
                writer.Write("Binary data here!");
                writer.Write(10);
                writer.Write(true);
                writer.Write(90f);
            }

            // Create hex dump
            using (var reader1 = new StreamReader("test.txt"))
            using (var writer1 = new StreamWriter("test.hex.txt"))
            {
                CreateHexDump(reader1, writer1);
            }

            // My version of hex dump
            string data2 = "SDDC___24 asd asd221e  asd as das d";  
            using (MemoryStream reader2 = new MemoryStream(Encoding.UTF8.GetBytes(data2), writable: false))
            using (MemoryStream writer2 = new MemoryStream())
            {
                CreateHexDumpCustom(reader2, writer2);
                string hexDump = Encoding.UTF8.GetString(writer2.ToArray());
                Console.WriteLine(hexDump);
            }

            Console.ReadKey();
        }

        static void CreateHexDump(StreamReader reader, StreamWriter writer)
        {
            int position = 0;
            
            while(!reader.EndOfStream)
            {
                char[] buffer = new char[16];
                int charsRead = reader.ReadBlock(buffer, 0, 16);
                writer.Write("{0}: ", String.Format("{0:x4}", position));
                position += charsRead;

                for (int i = 0; i < 16; i++)
                {
                    if(i < charsRead)
                    {
                        string hex = String.Format("{0:x2}", (byte)buffer[i]);
                        writer.Write($"{hex} ");
                    }
                    else
                    {
                        writer.Write("   ");
                    }
                    if (i == 7) writer.Write("-- ");
                    if (buffer[i] < 32 || buffer[i] > 250) buffer[i] = '.';
                }

                string bufferContents = new string(buffer);
                writer.WriteLine("   " + bufferContents.Substring(0, charsRead));
            }
        }

        static void CreateHexDumpCustom(Stream reader, Stream writer)
        {
            StreamReader sReader = new StreamReader(reader);
            StreamWriter sWriter = new StreamWriter(writer);

            const int BUFFER_SIZE = 16;
            int shiftFromStart = 0;
            
            while (!sReader.EndOfStream)
            {
                char[] buffer = new char[BUFFER_SIZE];
                int bytesRead = sReader.ReadBlock(buffer, 0, BUFFER_SIZE);
                sWriter.Write(String.Format("{0:x4}: ", shiftFromStart));
                shiftFromStart += bytesRead;

                // Writer buffer bytes
                for (int i = 0; i < BUFFER_SIZE; i++)
                {
                    if (i < bytesRead)
                        sWriter.Write(String.Format("{0:x2} ", (byte)buffer[i]));
                    else
                        sWriter.Write("   ");
                    if(i == 7)
                        sWriter.Write("-- ");
                }
                sWriter.Write("  ");

                // Write text content
                string content = new string(buffer.Take(bytesRead).Select(x => (byte)x).Select(x => x < 32 || x > 250 ? '.' : (char)x).ToArray());
                sWriter.Write(content);

                // Next line
                sWriter.Write(Environment.NewLine);

            }

            sWriter.Flush();
        }
    }
}
