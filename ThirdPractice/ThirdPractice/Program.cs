using System;

namespace ThirdPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Swap(2, 4);
            list.Doubling();
            list.RemoveRefNode(2);
            list.RemovingSecondRefNode(1);
            list.Insert(5, 8);
            Console.WriteLine(list.ToString());
        }
    }
}
