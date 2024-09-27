// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks;

Console.WriteLine("Hello, World!");

MyBanck myBanck = new MyBanck();
List<Task> tasks = new List<Task>();
object obj = new object();
Mutex mutex = new Mutex();
#region usin lock
//for (int i = 0; i < 10; i++)
//{


//    tasks.Add(Task.Factory.StartNew(() =>
//    {
//        for (int j = 0; j < 10; j++)
//        {
//            lock (obj)
//            {
//                myBanck.Deposit(10);
//            }
//        }
//    }));

//    tasks.Add(Task.Factory.StartNew(() =>
//    {
//        for (int j = 0; j < 10; j++)
//        {
//            lock (obj)
//            {
//                myBanck.Withdraw(10);
//            }
//        }
//    }));
//}
#endregion

#region With Mutex
for (int i = 0; i < 10; i++)
{
    tasks.Add(Task.Factory.StartNew(() =>
    {
        for (int j = 0; j < 10; j++)
        {
            bool havelock = false;
            try
            {
                havelock = mutex.WaitOne();
                myBanck.Deposit(10);
            }
            finally
            {
                if (havelock)
                    mutex.ReleaseMutex();
            }


        }
    }));

    tasks.Add(Task.Factory.StartNew(() =>
    {
        for (int j = 0; j < 10; j++)
        {
            bool havelock = false;
            try
            {
                havelock = mutex.WaitOne();
                myBanck.Withdraw(10);
            }
            finally
            {

                if (havelock)
                    mutex.ReleaseMutex();
            }

        }
    }));
}
#endregion
Task.WaitAll(tasks.ToArray());
Console.WriteLine($"Final balance is {myBanck.Balance}");
Console.ReadKey();
public class MyBanck
{
    public int Balance { get; private set; }

    public void Deposit(int amount)
    {
        Balance += amount;
    }
    public void Withdraw(int amount)
    {
        Balance -= amount;
    }
}

