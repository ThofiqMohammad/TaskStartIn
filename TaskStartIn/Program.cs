using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStartIn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task usage
            //Console.WriteLine("Started.....");
            //Task t1 = new Task(() => 
            //PrintNumbers());
            //t1.Start();

            //Task.Factory.StartNew(() => PrintAlphabet());

            //Console.WriteLine("Both the methods get caled.");

            //Task.Factory.StartNew(Dynamic, "?");
            //Task t2 = new Task(Dynamic, "/");
            //t2.Start();

            Task<int> factoryOut = Task.Factory.StartNew(FindLength, "Testing123");
            Task<int> taskOut = new Task<int>(FindLength, "test");
            taskOut.Start();

            Console.WriteLine(factoryOut.Result);
            Console.WriteLine(taskOut.Result);
            #endregion

            #region Task Cancellation
            //var cts = new CancellationTokenSource();
            //var token = cts.Token;
            //Task.Factory.StartNew(() => NonStopingLoop(token));
            //Console.ReadKey();
            //cts.Cancel();
            //Console.ReadKey();
            #endregion

            #region Chained Cancellation Token
            var palnned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(palnned.Token, preventative.Token);//Note emergency is not included intensionally
            Task.Factory.StartNew(() => NonStopingLoopWithChainToken(paranoid.Token));

            int i = 0;
            while (true)
            {
                Console.WriteLine("Wait" + i++);
                Thread.Sleep(2000);
                if(i == 5)
                {
                    emergency.Cancel();//Though called NonStopingLoopWithChainToken will keep working as  emergency is not part of CreateLinkedTokenSource
                }
            }
            #endregion

        }

        #region Task Cancellation
        private static void NonStopingLoop(CancellationToken token)
        {

            int i = 0;
            while (true)
            {
                //if (token.IsCancellationRequested)
                //    break; 
                //OR as below 
                token.ThrowIfCancellationRequested();
                Console.WriteLine(i++);
            }
        }
        #endregion

        #region Task usage
        public static void PrintNumbers()
        {
            for (int j = 0; j < 100; j++)
            {
                Console.WriteLine(j);
            }
        }
        public static void PrintAlphabet()
        {
            for (int j = 0; j < 100; j++)
            {
                Console.WriteLine("ABCD");
            }
        }
        public static void Dynamic(Object o)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.WriteLine(o);
            }
        }
        public static int FindLength(object o)
        {
            Console.WriteLine($"\nTask with Id {Task.CurrentId} processing object {o}....");
            return o.ToString().Length;
        }
        #endregion

        private static void NonStopingLoopWithChainToken(CancellationToken token)
        {

            int i = 0;
            while (true)
            {
                if (token.IsCancellationRequested)
                    break;

                Console.WriteLine(i++);
                Thread.Sleep(1000);
            }
        }
    }
}
