using System;
using System.Threading;

namespace CSharpStudy
{
    public class BasicThread
    {
        static void Main(string[] args)
        {
            //Example1();
            //Example2();
            //ThreadState();
            //InterruptingThread();

            ThreadSync();
        }

        static void Example1()
        {
            Thread t = new Thread(new ThreadStart(BasicThreading));

            Console.WriteLine("Starting thread...");
            t.Start();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main: {0}", i);
                Thread.Sleep(10);
            }

            Console.WriteLine("Starting thread...");
            t.Join();

            Console.WriteLine("Finished");
        }

        static void BasicThreading()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("BasicThreading: {0}", i);
                Thread.Sleep(10);
            }
        }

        static void Example2()
        {
            SideTask task = new SideTask(100);
            Thread t = new Thread(new ThreadStart(task.KeepAlive));
            t.IsBackground = false;

            Console.WriteLine("Starting thread...");
            t.Start();

            Thread.Sleep(100);

            Console.WriteLine("Aborting thread...");
            t.Abort();

            Console.WriteLine("Waiting until thread stops...");
            t.Join();

            Console.WriteLine("Finished");
        }

        static void ThreadState()
        {
            PrintThreadState(System.Threading.ThreadState.Running);
            PrintThreadState(System.Threading.ThreadState.StopRequested);
            PrintThreadState(System.Threading.ThreadState.SuspendRequested);
            PrintThreadState(System.Threading.ThreadState.Background);
            PrintThreadState(System.Threading.ThreadState.Unstarted);
            PrintThreadState(System.Threading.ThreadState.Stopped);
            PrintThreadState(System.Threading.ThreadState.WaitSleepJoin);
            PrintThreadState(System.Threading.ThreadState.Suspended);
            PrintThreadState(System.Threading.ThreadState.AbortRequested);
            PrintThreadState(System.Threading.ThreadState.Aborted);
            PrintThreadState(System.Threading.ThreadState.Aborted | System.Threading.ThreadState.Stopped);
        }
        static void PrintThreadState(ThreadState state)
        {
            Console.WriteLine("{0,-16} : {1}", state, (int)state);
        }

        static void InterruptingThread()
        {
            SideTask2 task = new SideTask2(100);
            Thread t = new Thread(new ThreadStart(task.KeepAlive));
            t.IsBackground = false;

            Console.WriteLine("Starting thread...");
            t.Start();

            Thread.Sleep(100);

            Console.WriteLine("Inturrupting thread...");
            t.Interrupt();

            Console.WriteLine("Waiting until thread stops");
            t.Join();

            Console.WriteLine("Finished");
        }

        static void ThreadSync()
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.Count);
        }
    }

    class SideTask
    {
        int count;

        public SideTask(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            try
            {
                while(count > 0)
                {
                    Console.WriteLine("{0} left", count--);
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count = =");
            }
            catch(ThreadAbortException e)
            {
                Console.WriteLine(e);
                Thread.ResetAbort();
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }
        }
    }

    class SideTask2
    {
        int count;

        public SideTask2(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            try
            {
                Console.WriteLine("Running thread isn't gonna be inturrupted");
                Thread.SpinWait(100000);

                while(count > 0)
                {
                    Console.WriteLine("{0} left", count--);
                    Console.WriteLine("Entering into WainJoinSleep State...");
                    Thread.Sleep(5);
                }
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }
        }
    }

    class Counter
    {
        const int LOOP_COUNT = 100;

        readonly object thisLock;

        private int count;
        public int Count { get { return count; } }

        public void Increase()
        {
            int loopCount = LOOP_COUNT;
            while (loopCount-- > 0)
            {
                /*
                lock (thisLock)
                {
                    count++;
                }*/
                Monitor.Enter(thisLock);
                try
                {
                    count++;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }

        public Counter()
        {
            thisLock = new object();
            count = 0;
        }

        public void Decrease()
        {
            int loopCount = LOOP_COUNT;
            while(loopCount-- > 0)
            {
                /*
                lock (thisLock)
                {
                    count--;
                }*/
                Monitor.Enter(thisLock);
                try
                {
                    count--;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }
    }
}
