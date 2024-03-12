namespace AppConHilos2;

class Program
{
    static void Main(string[] args)
    {
        Thread workerThread = new Thread(new ParameterizedThreadStart(Print));
        workerThread.Name = "Hilo de Print";
        CancellationTokenSource cst = new CancellationTokenSource();
        workerThread.Start(cst.Token);
        for (int i = 0; i < 10; i++) 
        {
            Console.WriteLine($"Principal thread: {i}");
            Thread.Sleep(200);
        }
        if (workerThread.IsAlive)  {
            cst.Cancel();
        }
    }

    static void Print(object? obj) {
        Thread currentThread = Thread.CurrentThread;
        if (obj == null) {
            return;
        }
        CancellationToken cancellationToken = (CancellationToken)obj;
        currentThread.IsBackground = false;
        
        for (int i = 11; i < 20; i++) 
        {
            if (cancellationToken.IsCancellationRequested) {
                Console.WriteLine("En la iteracion {0}, la cancelacion ha sido solicitada....", i);
                break;
            }
            Console.WriteLine($"Print thread: {i}");
            Thread.Sleep(1000);
        }
    }
}
