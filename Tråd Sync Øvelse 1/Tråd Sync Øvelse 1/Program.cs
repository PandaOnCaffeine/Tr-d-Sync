using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Tråd_Sync_Øvelse_1
{
    internal class Program
    {
        static int _fællesFil = 0;
        static object _lock = new object();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t1 = new Thread(AddOne);
                t1.Start();
                Console.WriteLine($"Shared resorce: {_fællesFil} |called addone");

                Thread t2 = new Thread(MinusOne);
                t2.Start();
                Console.WriteLine($"Shared resorce: {_fællesFil} |called minusone");
            }
            Console.ReadLine();
        }
        static void AddOne()
        {
            Monitor.Enter(_lock);
            try
            {
                _fællesFil++;
            }
            finally
            {
                Monitor.Exit(_lock);
            }                        
        }
        static void MinusOne()
        {
            Monitor.Enter(_lock);
            
            try
            {
                _fællesFil--;
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
    
}
