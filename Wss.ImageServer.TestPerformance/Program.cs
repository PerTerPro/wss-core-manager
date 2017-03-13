using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSS.ImageImbo.Lib;

namespace Wss.ImageServer.TestPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            ImboService imboService = new ImboService();
            imboService.PostImgToImboFromFile(@"C:\Users\xuantrang\Pictures\anh1.png", "wss_write", "123websosanh@195", "avatar", "https://172.22.1.226", 443);
            return;


            Console.WriteLine("NumberWorker:");
            int numberWorker = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Link:");

            for (int i = 0; i < numberWorker; i++)
            {
        
                Task t  = new Task(new Action(() =>
                {
                    string nameThead = i.ToString();
                    string url = @"https://img.websosanh.vn/v2/users/adsbanner/images/q9yDYIgZJF6g.jpg?width=200&v=v1&compress=85";
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
