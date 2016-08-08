using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace AuxiliarKinect.FuncoesBasicas
{
    public class Worker
    {
        List<Skeleton> esqueletos = new List<Skeleton>();
        public void DoWork()
        {
            while (!_shouldStop)
            {
                if (esqueletos != null && esqueletos.Count != 0)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Lucas\Documents\logs kinect\log.txt",true))
                    {
                        foreach (Skeleton skeleton in esqueletos)
                        {
                            JointCollection joint = skeleton.Joints;

                            foreach (Joint j in joint)
                            {
                                file.WriteLine(j.JointType + " X : " + j.Position.X);
                                file.WriteLine(j.JointType + " X : " + j.Position.Y);
                                file.WriteLine(j.JointType + " X : " + j.Position.Z);
                            }
                        }
                    }
                    esqueletos.Clear();
                    RequestStop();
                }
            }
            Console.WriteLine("worker thread: terminating gracefully.");
        }
        
        public void setEsqueleto(List<Skeleton> esqueletos)
        {
            this.esqueletos = esqueletos;
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Volatile is used as hint to the compiler that this data 
        // member will be accessed by multiple threads. 
        private volatile bool _shouldStop;
    }


   /* public class WorkerThreadExample
    {
        static void Main()
        {
            // Create the thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("main thread: Starting worker thread...");

            // Loop until worker thread activates. 
            while (!workerThread.IsAlive) ;

            // Put the main thread to sleep for 1 millisecond to 
            // allow the worker thread to do some work:
            Thread.Sleep(1);

            // Request that the worker thread stop itself:
            workerObject.RequestStop();

            // Use the Join method to block the current thread  
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("main thread: Worker thread has terminated.");
        }
    }*/
}
