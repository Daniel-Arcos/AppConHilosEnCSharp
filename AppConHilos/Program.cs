namespace AppConHilos;

class Program
{
    public static void DoTrabajoPesado() 
    {
        Console.WriteLine("DoTrabajoPesado: Estoy levantando un camion!");
        Thread.Sleep(1000);
        Console.WriteLine("DoTrabajoPesado: Cansado! Necesito una siesta de 3 seg!");
        Thread.Sleep(1000);
        Console.WriteLine("DoTrabajoPesado: 1...");
        Thread.Sleep(1000);
        Console.WriteLine("DoTrabajoPesado: 2...");
        Thread.Sleep(1000);
        Console.WriteLine("DoTrabajoPesado: 3...");
        Console.WriteLine("DoTrabajoPesado: Ya desperte.");
    }

    public static void DoAlgo() 
    {
        Console.WriteLine("DoAlgo: Oye! Haciendo algo aqui!");
        for (int i = 0; i < 20; i++) {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
        Console.WriteLine("DoAlgo: Ya termine.");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("El Main Thread comienza aqui.");
        Thread backgroundThread  = new Thread(new ThreadStart(Program.DoTrabajoPesado));
        backgroundThread.Start();
        Program.DoAlgo();
        Console.WriteLine("El Main Thread termina aqui.");
    }
}
