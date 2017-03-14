using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wss.ImageServer.TestPerformance
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("NumberWorker:");
            int numberWorker = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Link:");

            for (int i = 0; i < numberWorker; i++)  
            {
        
                Task t  = new Task(new Action(() =>
                {
                    string nameThead = i.ToString();
                    string url = @"http://192.168.100.36:81/index.php?collection=xuantrang&image=49is1vsdxj73v&extension=jpg&size=100x700&compressQuality=10";
                    WorkerTest w = new WorkerTest(url, nameThead);
                    w.Run();
                   
                }));
                t.Start();

                Thread.Sleep(1000);
            }
            Thread.Sleep(100000);
        }
    }
}
