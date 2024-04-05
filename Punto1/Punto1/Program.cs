using System;

// Clase Barco
public class Barco
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int CapacidadPasajeros { get; set; }
    public int CapacidadCarga { get; set; }

    public Barco(string nombre, string tipo, int capacidadPasajeros, int capacidadCarga)
    {
        Nombre = nombre;
        Tipo = tipo;
        CapacidadPasajeros = capacidadPasajeros;
        CapacidadCarga = capacidadCarga;
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Tipo: {Tipo}");
        Console.WriteLine($"Capacidad de pasajeros: {CapacidadPasajeros}");
        Console.WriteLine($"Capacidad de carga: {CapacidadCarga}");
    }
}

// Clase GPS
public class GPS
{
    public int CoordenadaX { get; set; }
    public int CoordenadaY { get; set; }
    public string FechaHora { get; set; }
    public int DiasTripulado { get; set; }
}

// Clase abstracta Tripulante
public abstract class Tripulante
{
    public int NumeroCarnet { get; set; }
    public int Edad { get; set; }
    public int TiempoEmpresa { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public char Sexo { get; set; }
    public Barco Barco { get; set; }

    public abstract float Sueldo();
    public abstract void MostrarDatos();
}

// Clase Capitán
public class Capitan : Tripulante
{
    public int HorasExperticia { get; set; }
    public const float SueldoBase = 4500000;
    public float Bono { get; set; }

    public Capitan(int horasExperticia)
    {
        HorasExperticia = horasExperticia;
    }

    public override float Sueldo()
    {
        if (HorasExperticia >= 5000 && HorasExperticia < 150000)
            Bono = SueldoBase * 0.20f;
        else if (HorasExperticia >= 150000 && HorasExperticia < 300000)
            Bono = SueldoBase * 0.40f;
        else if (HorasExperticia >= 300000)
            Bono = SueldoBase * 0.75f;

        return SueldoBase + Bono;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"Número de Carnet: {NumeroCarnet}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Tiempo en la empresa: {TiempoEmpresa}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Sexo: {Sexo}");
        Console.WriteLine($"Horas de Experticia: {HorasExperticia}");
        Console.WriteLine($"Sueldo Total: {Sueldo()}");
    }
}

// Clase JefeDeFlota
public class JefeDeFlota : Tripulante
{
    public int PesoPescado { get; set; }
    public int PesoMariscos { get; set; }
    public const float SueldoBase = 35000000;
    public float BonoPescado { get; set; }
    public float BonoMariscos { get; set; }

    public override float Sueldo()
    {
        return SueldoBase + BonoPescado + BonoMariscos;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"Número de Carnet: {NumeroCarnet}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Tiempo en la empresa: {TiempoEmpresa}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Sexo: {Sexo}");
        Console.WriteLine($"Peso de Pescado: {PesoPescado}");
        Console.WriteLine($"Peso de Mariscos: {PesoMariscos}");
        Console.WriteLine($"Sueldo Total: {Sueldo()}");
    }
}

// Clase Marinero
public class Marinero : Tripulante
{
    public int PesoTotalPescado { get; set; }
    public const float SueldoBase = 90000;
    public float Bono { get; set; }

    public override float Sueldo()
    {
        if (PesoTotalPescado >= 1)
            Bono = SueldoBase * 0.25f;

        return SueldoBase + Bono;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"Número de Carnet: {NumeroCarnet}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Tiempo en la empresa: {TiempoEmpresa}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Sexo: {Sexo}");
        Console.WriteLine($"Peso Total de Pescado: {PesoTotalPescado}");
        Console.WriteLine($"Sueldo Total: {Sueldo()}");
    }
}

// Clase Principal
public class Principal
{
    public static void Main(string[] args)
    {
        // Crear objetos
        Barco barco = new Barco("Barco1", "Tipo1", 100, 500);
        GPS gps = new GPS();
        Capitan capitan = new Capitan(200000);
        JefeDeFlota jefeDeFlota = new JefeDeFlota();
        Marinero[] marineros = new Marinero[7];

        // Ingresar datos de marineros
        for (int i = 0; i < marineros.Length; i++)
        {
            marineros[i] = new Marinero();
            marineros[i].NumeroCarnet = i + 1;
            marineros[i].Edad = 30 + i;
            marineros[i].TiempoEmpresa = 5 + i;
            marineros[i].Nombre = $"Marinero{i + 1}";
            marineros[i].Telefono = $"12345678{i}";
            marineros[i].Sexo = 'M';
            marineros[i].PesoTotalPescado = 10 * (i + 1);
        }

        // Mostrar datos de marineros
        foreach (var marinero in marineros)
        {
            marinero.MostrarDatos();
            Console.WriteLine("-----------------------------");
        }
    }
}

