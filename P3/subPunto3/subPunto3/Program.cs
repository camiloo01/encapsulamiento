using System;

// Clase principal Vehiculo
public abstract class Vehiculo
{
    // Atributos comunes
    protected string matricula;
    protected int velocidad;

    // Constructor
    public Vehiculo(string matricula)
    {
        this.matricula = matricula;
        this.velocidad = 0;
    }

    // Método virtual para acelerar
    public virtual void Acelerar(int incrementoVelocidad)
    {
        velocidad += incrementoVelocidad;
    }

    // Método para mostrar la información del vehículo
    public override string ToString()
    {
        return $"Matrícula: {matricula}, Velocidad: {velocidad} km/h";
    }
}


// Clase Coche
public class Coche : Vehiculo
{
    
    private int numPuertas;

    // Constructor
    public Coche(string matricula, int numPuertas) : base(matricula)
    {
        this.numPuertas = numPuertas;
    }

    // numero de puertas
    public int GetNumPuertas()
    {
        return numPuertas;
    }
}

// Clase Camion
public class Camion : Vehiculo
{
    
    private Remolque remolque;

    // Constructor
    public Camion(string matricula) : base(matricula)
    {
        this.remolque = null;
    }

    // agregar un remolque
    public void PonRemolque(Remolque remolque)
    {
        this.remolque = remolque;
    }

    // Método para quitar el remolque
    public void QuitaRemolque()
    {
        this.remolque = null;
    }

    // Sobrescribe el método Acelerar para el camión
    public override void Acelerar(int incrementoVelocidad)
    {
        if (remolque != null && velocidad + incrementoVelocidad > 100)
        {
            throw new DemasiadoRapidoException("El camión con remolque no puede superar los 100 km/h");
        }
        else
        {
            base.Acelerar(incrementoVelocidad);
        }
    }

    // Método para mostrar la información del camión (incluyendo remolque si lo tiene)
    public override string ToString()
    {
        string infoCamion = base.ToString();
        if (remolque != null)
        {
            infoCamion += $", Remolque: {remolque}";
        }
        return infoCamion;
    }
}

// Clase Remolque
public class Remolque
{
    // Atributo de peso
    private int peso;

    // Constructor
    public Remolque(int peso)
    {
        this.peso = peso;
    }

    // Método para mostrar la información del remolque
    public override string ToString()
    {
        return $"Peso: {peso} kg";
    }
}

// Clase de excepción DemasiadoRapidoException
public class DemasiadoRapidoException : Exception
{
    // Constructor
    public DemasiadoRapidoException(string mensaje) : base(mensaje)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Crear un coche y acelerar
            Coche coche = new Coche("1234ABC", 5);
            coche.Acelerar(50);
            Console.WriteLine("Coche:");
            Console.WriteLine(coche);

            // Crear un camión y acelerar
            Camion camion = new Camion("5678DEF");
            camion.Acelerar(80);
            Console.WriteLine("\nCamión:");
            Console.WriteLine(camion);

            // Agregar un remolque al camión y acelerar
            Remolque remolque = new Remolque(500);
            camion.PonRemolque(remolque);
            camion.Acelerar(30);
            Console.WriteLine("\nCamión con remolque:");
            Console.WriteLine(camion);

            // Intentar acelerar más allá de los 100 km/h
            camion.Acelerar(30);
        }
        catch (DemasiadoRapidoException e)
        {
            Console.WriteLine($"\nError: {e.Message}");
        }
    }
}
