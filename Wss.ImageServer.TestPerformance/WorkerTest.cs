using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wss.ImageServer.TestPerformance
{
    public class WorkerTest
    {
        private string url = "";
        private string nameWorker;


        public WorkerTest(string url, string nameWorker)
        {
            this.url = url;
            this.nameWorker = nameWorker;
        }

        public void Run()
        {
            DateTime dtStart = DateTime.Now;
            int iCount = 1;
            while (true)
            {
                WebClient client = new WebClient();
                byte[] arDatay = client.DownloadData(url);
                iCount++;
                int timeSecond = (int) (DateTime.Now - dtStart).TotalSeconds + 1;
                int perCountToSecond = iCount/timeSecond;
               if(iCount%100==0)   Console.WriteLine(string.Format("Worker {0} n/s {1}", nameWorker, perCountToSecond));
            }
        }
    }

}
