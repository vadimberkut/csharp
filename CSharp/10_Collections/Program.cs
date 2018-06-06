using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Collections
{
    class Duck : IComparable<Duck>
    {
        public int Age { get; set; }

        public int CompareTo(Duck other)
        {
            if (this.Age < other.Age) return -1;
            else if (this.Age > other.Age) return 1;
            else return 0;
        }
    }

    class DuckComparer: IComparer<Duck>
    {
        public int Compare(Duck first, Duck second)
        {
            if (first.Age < second.Age) return 1;
            else if (first.Age > second.Age) return -1;
            else return 0;
        }
    }

    class Program
    {
        static void PrintDucks(IEnumerable<Duck> ducks)
        {
            string msg = ducks.Select(x => x.Age.ToString()).Aggregate((x, y) => $"{x}, {y}");
            Console.WriteLine(msg);
        }
        static void Main(string[] args)
        {
            // IComparable<T>
            var ducks1 = new List<Duck>() {
                new Duck { Age = 100 },
                new Duck { Age = 5 },
                new Duck { Age = 43 },
                new Duck { Age = 1 },
            };
            ducks1.Sort();
            PrintDucks(ducks1);
            Console.WriteLine(); Console.WriteLine();

            // IComparer<T>
            var ducks2 = new List<Duck>() {
                new Duck { Age = 100 },
                new Duck { Age = 5 },
                new Duck { Age = 43 },
                new Duck { Age = 1 },
            };
            ducks2.Sort(new DuckComparer());
            PrintDucks(ducks2);
            Console.WriteLine(); Console.WriteLine();


            // Dictionary
            Dictionary<string, int> dict1 = new Dictionary<string, int>() { { "A", 1 }, { "C", 3 }, { "B", 2 } };
            foreach(KeyValuePair<string, int> kvp in dict1)
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }
            Console.WriteLine(); Console.WriteLine();

            // Converting collections
            Queue<string> queue1 = new Queue<string>();
            queue1.Enqueue("1");
            Stack<string> stack1 = new Stack<string>(queue1);
            stack1.Push("2");
            List<string> list1 = new List<string>(stack1);
            list1.Add("3");

            Console.ReadKey();
        }
    }
}
