using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _12_Serializaion
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy guy1 = new Guy
            {
                Name = "John",
                Age = 23,
                Dog = new Dog
                {
                    Name = "Liko",
                    Age = 3
                }
            };
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using(Stream output = File.Create("test1.dat"))
            {
                binaryFormatter.Serialize(output, guy1);
            }
            using(Stream input = File.OpenRead("test1.dat"))
            {
                Guy gu1_1 = binaryFormatter.Deserialize(input) as Guy; 
            }


        }
    }

    [Serializable]
    class Guy
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Dog Dog { get; set; }

    }

    [Serializable]
    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
