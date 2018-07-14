using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DEQUE_ITEM_COUNT = 1000000;

            Stopwatch sw = new Stopwatch();

            // Insert
            sw.Reset();
            sw.Start();
            var deque1 = new Deque<int>();
            for (int i = 0; i < DEQUE_ITEM_COUNT; i++)
            {
                deque1.InsertFront(i);
                deque1.InsertRear(DEQUE_ITEM_COUNT - i);
            }
            sw.Stop();
            Console.WriteLine("Deque<int>: InsertFront, InsertRear: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            var deque2 = new Deque<object>();
            for (int i = 0; i < DEQUE_ITEM_COUNT; i++)
            {
                deque2.InsertFront(new TestClass());
                deque2.InsertRear(new TestClass());
            }
            sw.Stop();
            Console.WriteLine("Deque<object>: InsertFront, InsertRear: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            Console.ReadKey();
        }

        /// <summary>
        /// Deque support operations from both stach and queue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        interface IDeque<T>
        {
            void InsertFront(T item);
            void InsertRear(T item);
            void DeleteFront();
            void DeleteRear();

            T GetFront();
            T GetRear();
            bool IsEmpty();
            bool IsFull();
        }

        class DequeNode<T>
        {
            public T Data { get; set; } = default(T);
            public DequeNode<T> PrevNode { get; set; } = null;
            public DequeNode<T> NextNode { get; set; } = null;
        }

        class Deque<T> : IDeque<T>
        {
            private DequeNode<T> FrontNode = null;
            private DequeNode<T> RearNode = null;

            public void InsertFront(T item)
            {
                if (this.IsEmpty())
                {
                    var nextNode = new DequeNode<T>
                    {
                        Data = item,
                        PrevNode = null,
                        NextNode = null
                    };
                    this.FrontNode = nextNode;
                    this.RearNode = nextNode;
                }
                else
                {
                    var nextNode = new DequeNode<T>
                    {
                        Data = item,
                        PrevNode = null,
                        NextNode = this.FrontNode
                    };
                    this.FrontNode = nextNode;
                }
            }

            public void InsertRear(T item)
            {
                if (this.IsEmpty())
                {
                    var nextNode = new DequeNode<T>
                    {
                        Data = item,
                        PrevNode = null,
                        NextNode = null
                    };
                    this.FrontNode = nextNode;
                    this.RearNode = nextNode;
                }
                else
                {
                    var nextNode = new DequeNode<T>
                    {
                        Data = item,
                        PrevNode = this.RearNode,
                        NextNode = null
                    };
                    this.RearNode = nextNode;
                }
            }

            public void DeleteFront()
            {
                if (this.IsEmpty())
                {
                    return;
                }

                this.FrontNode = this.FrontNode.NextNode;
            }

            public void DeleteRear()
            {
                if (this.IsEmpty())
                {
                    return;
                }

                this.RearNode = this.RearNode.PrevNode;
            }

            public T GetFront()
            {
                if(this.IsEmpty())
                {
                    throw new InvalidOperationException("Deque is empty");
                }

                return this.FrontNode.Data;
            }

            public T GetRear()
            {
                if (this.IsEmpty())
                {
                    throw new InvalidOperationException("Deque is empty");
                }

                return this.RearNode.Data;
            }

            public bool IsEmpty()
            {
                return this.FrontNode == null && this.RearNode == null;
            }

            public bool IsFull()
            {
                // I don't see any neccesity of this method
                throw new NotImplementedException();
            }
        }

        class TestClass
        {
            public int MyProperty1 { get; set; }
            public int MyProperty2 { get; set; }
            public int MyProperty3 { get; set; }
        }
    }
}
