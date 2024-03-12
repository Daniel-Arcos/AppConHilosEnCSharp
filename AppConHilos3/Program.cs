namespace AppConHilos3;

class Program
{
    
    public class Persona {
        public String Nombre {get; set;}
        public int Edad {get; set;}
        public String Sexo {get; set;}

        public Persona(String nombre, int edad, String sexo) {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Sexo = sexo;
        }
    }

    static void TareaDeFondo (Object? stateInfo) {
        Console.WriteLine($"Hilo 1: Hola soy un hilo sin uso de de paraemetros desde ThreadPool");
        Thread.Sleep(1500);
    }

    static void TareaDeFondoConParametro (Object? stateInfo) {
        if (stateInfo == null) {
            return;
        }

        Persona data = (Persona)stateInfo;
        Console.WriteLine($"Hilo 2: Hola {data.Nombre}, tu edad es {data.Edad}.");
        Thread.Sleep(500);
    }

    static void Main (string[] args) {
        int workers, ports;
        ThreadPool.GetMaxThreads(out workers, out ports);
        Console.WriteLine($"Maximos hilos de trabajo: {workers}");
        Console.WriteLine($"Maximos puertos para hilos: {ports}");

        ThreadPool.GetMinThreads(out workers, out ports);
        Console.WriteLine($"Minimos hilos de trabajo: {workers}");
        Console.WriteLine($"Minimos puertos (completion port) para hilos: {ports}");

        ThreadPool.GetAvailableThreads(out workers, out ports);
        Console.WriteLine($"Hilos de trabajo disponibles: {workers}");
        Console.WriteLine($"Hilos de puertos (completion port) disponibles: {ports}");

        int processCount = Environment.ProcessorCount;
        Console.WriteLine($"No. de procesadores disponibles en el sistema: {processCount}");
        Console.WriteLine($"--------------------------------------");

        ThreadPool.QueueUserWorkItem(TareaDeFondo);
        ThreadPool.GetAvailableThreads(out workers, out ports);
        Console.WriteLine($"Hilos de trabajo disponibles despues del hilo 1: {workers}");


        Persona p = new Persona("Daniel", 20, "Hombre");
        ThreadPool.QueueUserWorkItem(TareaDeFondoConParametro, p);
        ThreadPool.GetAvailableThreads(out workers, out ports);
        Console.WriteLine($"Hilos de trabajo disponibles despues del hilo 2: {workers}");

    Thread.Sleep(2000);
        ThreadPool.GetAvailableThreads(out workers, out ports);
        Console.WriteLine($"Hilos de trabajo disponibles al final: {workers}");
        Console.ReadKey();

    }
}

