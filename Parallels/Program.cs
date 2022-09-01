
for (int i = 0; i < 1; i++)
{
    Parallels parallels = new Parallels(i);
}
class Parallels
{
    Thread myThread;

    public Parallels(int i)
    {
        myThread = new Thread(Run);
        myThread.Start();
    }
    public void Loader1()
    {
        myThread.Join(500);
        Console.WriteLine("Loader1 delivered");
    }
    public void Loader2()
    {
        myThread.Join(600);
        Console.WriteLine("Loader2 delivered");
    }
    public void Courer2()
    {
        myThread.Join(1500);
        Parallel.Invoke(Loader1, Loader2);
        Console.WriteLine("courer2 delivered");
    }
    public void Courer1()
    {
        myThread.Join(1000);
        Console.WriteLine("courer1 delivered");
    }

    public void Run()
    {
        string s = "Delivered";
        ThreadPool.QueueUserWorkItem((s) => Parallel.Invoke(Courer1, Courer2), s);
        myThread.Join(3000);
        Console.WriteLine("Delivered");
    }
}
