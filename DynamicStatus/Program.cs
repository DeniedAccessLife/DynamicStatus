using System;
using System.ComponentModel;
using System.Threading;

namespace DynamicStatus
{
    class Program
    {
        private static string token;
        private static BackgroundWorker worker = new BackgroundWorker();

        static void Main()
        {
            worker.DoWork += worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            Console.WriteLine("Starting Application...");
            Console.WriteLine("Waiting for an authorization token...");
            token = Console.ReadLine();
            worker.RunWorkerAsync();
            Console.ReadKey();
        }

        static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random random = new Random();
            int delay = random.Next(30, 60);
            Thread.Sleep(delay * 1000);
            
            Console.WriteLine(Utils.Request(token));
        }

        static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
}
