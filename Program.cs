using System;

namespace Generics_And_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];
            a[0] = default(int);
            int? b = 4;
            if(b.HasValue) Console.WriteLine(b.Value);
           
            Console.WriteLine(b.Value == 4 ? 2 : 0);
            b = null;
            var y = b ?? 10;
            Console.WriteLine(y);
        }
    }
}
