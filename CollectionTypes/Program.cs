using System;
using System.Collections.Generic;
//Collection Typess
namespace CollectionTypes
{
    class Program
    {
        static void Main(string[] args)
        {        
            List<int> oldyears = new List<int>();
            oldyears.Add(1996);
            oldyears.Add(1997);
            oldyears.Add(1998);
            oldyears.Add(1999);
            oldyears.Add(2000);
            oldyears.Add(2001);
            oldyears.Add(2002);
            oldyears.Add(2003);
            oldyears.Add(2004);
            oldyears.Add(2005);

            IEnumerable<int> enumarable = (IEnumerable<int>)oldyears;
            //foreach (var item in enumarable)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine('\n');
            IEnumerator<int> enumerator = oldyears.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.ToString());
            }

            Console.WriteLine('\n');

            IEnumerator<int> enumerator1 = enumarable.GetEnumerator();

            Iterate19To2000(enumerator1);
            Console.ReadLine();
        }

        static void Iterate19To2000(IEnumerator<int> _enumerator)
        {
            while (_enumerator.MoveNext())
            {
                Console.WriteLine(_enumerator.Current.ToString());
                if (Convert.ToInt16(_enumerator.Current) > 2000)
                {
                    Iterate2001ToAbove(_enumerator);
                }
            }
        }
        static void Iterate2001ToAbove(IEnumerator<int> _enumerator)
        {
            while (_enumerator.MoveNext())
            {
                Console.WriteLine(_enumerator.Current.ToString());              
            }
        }
    }
}
