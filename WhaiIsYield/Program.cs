using System;
using System.Collections.Generic;
//What is Yield
namespace WhaiIsYield
{
    class Program
    {
        static List<int> MyList = new List<int>();
        static void FillValues()
        {
            MyList.Add(1);
            MyList.Add(2);
            MyList.Add(3);
            MyList.Add(4);
            MyList.Add(5);
        }

        static void Main(string[] args)
        {
            FillValues();
            foreach (int i in MyList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("With temp[]");
            foreach (var item in Filter())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Get with yield");
            foreach (var item in Filter1())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Running Total");

            foreach (var item in RuningTotal())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static IEnumerable<int> Filter()
        {
            List<int> temp = new List<int>();
            foreach (int i in MyList)
            {
                if(i > 3)
                {
                    temp.Add(i);
                }
            }
            return temp;
        }

        static IEnumerable<int> Filter1()
        {
            foreach (int i in MyList)
            {
                if (i > 3)
                {
                    yield return i;
                }
            }

        }
        static IEnumerable<int> RuningTotal()
        {
            int runningtotal = 0;
            foreach (int item in MyList)
            {
                runningtotal += item;
                yield return (runningtotal);
            }
        }
    }
}
