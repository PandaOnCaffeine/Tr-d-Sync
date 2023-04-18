using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tråd_Sync_Øvelse_2_3
{
    internal class Program
    {
        static readonly object _lock = new object();
        static int _sum = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t1 = new Thread(stars);
                t1.Start();

                Thread t2 = new Thread(hashtag);
                t2.Start();
            }

            Console.ReadLine();
        }
        static void stars()
        {
            Monitor.Enter(_lock);
            try
            {
                _sum+= 60;
                Console.WriteLine($"************************************************************ {_sum}");
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
        static void hashtag()
        {
            Monitor.Enter(_lock);
            try
            {
                _sum += 60;
                Console.WriteLine($"############################################################ {_sum}");
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
}
