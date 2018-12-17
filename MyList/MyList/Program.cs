using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListt
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList<int>();

            for (var i = 0; i < 10; i++)
            {
                myList.Add(i);
            }
            myList.Insert(11,5);
            myList.DeleteAt(5);
            myList.Delete(5);
            foreach (var item in myList)
            {
                Console.WriteLine( item);
            }
            Console.WriteLine(myList.Length);
        }
    }
}
