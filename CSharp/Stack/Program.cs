using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            const int STACK_BLOCK_SIZE = 1000;
            const int STACK_ITEM_COUNT = 500000;

            Stopwatch sw = new Stopwatch();

            // ArrayBasedStack
            sw.Reset();
            sw.Start();
            IArrayBasedStack<int> stack1 = new ArrayBasedStack<int>(STACK_BLOCK_SIZE);
            for (int i = 0; i < STACK_ITEM_COUNT; i++)
            {
                stack1.Push(i);
            }
            sw.Stop();
            Console.WriteLine("ArrayBasedStack: Push <int>: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            IArrayBasedStack<string> stack2 = new ArrayBasedStack<string>(STACK_BLOCK_SIZE);
            for (int i = 0; i < STACK_ITEM_COUNT; i++)
            {
                stack2.Push($"TestString{i}");
            }
            sw.Stop();
            Console.WriteLine("ArrayBasedStack: Push <string>: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            IArrayBasedStack<bool> stack3 = new ArrayBasedStack<bool>(STACK_BLOCK_SIZE);
            for (int i = 0; i < STACK_ITEM_COUNT; i++)
            {
                stack3.Push(i % 2 == 0);
            }
            sw.Stop();
            Console.WriteLine("ArrayBasedStack: Push <bool>: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            IArrayBasedStack<object> stack4 = new ArrayBasedStack<object>(STACK_BLOCK_SIZE);
            for (int i = 0; i < STACK_ITEM_COUNT; i++)
            {
                stack4.Push(new object());
            }
            sw.Stop();
            Console.WriteLine("ArrayBasedStack: Push <object>: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            // LinkedListBasedStack
            sw.Reset();
            sw.Start();
            ILinkedListBasedStack<int> stack1_1 = new LinkedListBasedStack<int>();
            for (int i = 0; i < STACK_ITEM_COUNT; i++)
            {
                stack1_1.Push(i);
            }
            sw.Stop();
            Console.WriteLine("LinkedListBasedStack: Push <int>: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            ILinkedListBasedStack<string> stack1_2 = new LinkedListBasedStack<string>();
            for (int i = 0; i < STACK_ITEM_COUNT; i++)
            {
                stack1_2.Push(i.ToString());
            }
            sw.Stop();
            Console.WriteLine("LinkedListBasedStack: Push <string>: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            ILinkedListBasedStack<bool> stack1_3 = new LinkedListBasedStack<bool>();
            for (int i = 0; i < STACK_ITEM_COUNT; i++)
            {
                stack1_3.Push(i % 2 == 0);
            }
            sw.Stop();
            Console.WriteLine("LinkedListBasedStack: Push <bool>: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            ILinkedListBasedStack<object> stack1_4 = new LinkedListBasedStack<object>();
            for (int i = 0; i < STACK_ITEM_COUNT; i++)
            {
                stack1_4.Push(i);
            }
            sw.Stop();
            Console.WriteLine("LinkedListBasedStack: Push <object>: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    interface IArrayBasedStack<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty();
    }

    class ArrayBasedStack<T> : IArrayBasedStack<T>
    {
        private const int INITIAL_STACK_SIZE = 1000;
        private int BlockSize = INITIAL_STACK_SIZE; // Will be used for stack size increase
        private T[] Store;
        private int TopIndex = -1;

        public ArrayBasedStack()
        {
            this.Store = new T[INITIAL_STACK_SIZE];
        }

        /// <summary>
        /// Creates stack with specified initial size
        /// </summary>
        /// <param name="size"></param>
        public ArrayBasedStack(int size)
        {
            this.BlockSize = size;
            this.Store = new T[size];
        }

        public bool IsEmpty()
        {
            return this.TopIndex == -1;
        }

        /// <summary>
        /// Returns top element of stack
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if(this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty. Can't return top item");
            }
            return this.Store[this.TopIndex];
        }

        /// <summary>
        /// Removes and returns top element of stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty. Can't return top item");
            }

            T topItem = this.Store[this.TopIndex];
            this.Store[this.TopIndex] = default(T); // Rewrite top item with default
            this.TopIndex -= 1;
            return topItem;
        }

        /// <summary>
        /// Adds item to stack
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if(this.TopIndex + 1 == this.Store.Length)
            {
                // Expand store
                T[] newStore = new T[this.Store.Length + this.BlockSize];
                for (int i = 0; i < this.Store.Length; i++)
                {
                    newStore[i] = this.Store[i];
                }
                this.Store = newStore;

                // Throw exception

            }
            // Push item
            this.Store[this.TopIndex + 1] = item;
            this.TopIndex += 1;
        }
    }

    interface ILinkedListBasedStack<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty();
    }

    

    class StackNode<T>
    {
        public T Data { get; set; } = default(T);
        public StackNode<T> Next { get; set; } = null;
    }

    class LinkedListBasedStack<T> : ILinkedListBasedStack<T>
    {
        private StackNode<T> Root = null;

        public bool IsEmpty()
        {
            return this.Root == null;
        }

        public T Peek()
        {
            return this.Root.Data;
        }

        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty. Can't return top item");
            }
            var popped = this.Root;
            this.Root = this.Root.Next;
            return popped.Data;
        }

        public void Push(T item)
        {
            var nextRoot = new StackNode<T>
            {
                Data = item,
                Next = this.Root
            };
            this.Root = nextRoot;
        }
    }
}
