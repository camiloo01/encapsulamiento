using System;
using System.Collections.Generic;

public class Empleado
{
    // Atributos
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string DNI { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public double Salario { get; set; }
    public Empleado Supervisor { get; set; }

    // Constructor
    public Empleado(string nombre, string apellidos, string dni, string direccion, string telefono, double salario)
    {
        Nombre = nombre;
        Apellidos = apellidos;
        DNI = dni;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
        Supervisor = null;
    }

    // Método para imprimir los datos del empleado
    public virtual void Imprimir()
    {
        Console.WriteLine("Datos del empleado:");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"DNI: {DNI}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Salario: {Salario}");
        if (Supervisor != null)
            Console.WriteLine($"Supervisor: {Supervisor.Nombre} {Supervisor.Apellidos}");
        else
            Console.WriteLine("Supervisor: No asignado");
    }

    // Método para cambiar el supervisor del empleado
    public void CambiarSupervisor(Empleado nuevoSupervisor)
    {
        Supervisor = nuevoSupervisor;
    }

    // Método para incrementar el salario del empleado
    public virtual void IncrementarSalario()
    {
        // Incremento del 5% anual
        Salario *= 1.05;
    }
}

public class Secretario : Empleado
{
    // Atributos adicionales de Secretario
    public string Despacho { get; set; }
    public string NumeroFax { get; set; }

    // Constructor
    public Secretario(string nombre, string apellidos, string dni, string direccion, string telefono, double salario, string despacho, string numeroFax)
        : base(nombre, apellidos, dni, direccion, telefono, salario)
    {
        Despacho = despacho;
        NumeroFax = numeroFax;
    }

    // Sobreescribe el método Imprimir para el secretario
    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine($"Despacho: {Despacho}");
        Console.WriteLine($"Número de Fax: {NumeroFax}");
    }

    // Sobreescribe el método IncrementarSalario para el secretario
    public override void IncrementarSalario()
    {
        // Incremento del 5% anual
        Salario *= 1.05;
    }
}

public class Vendedor : Empleado
{
    // Atributos adicionales de Vendedor
    public string MatriculaCoche { get; set; }
    public string MarcaCoche { get; set; }
    public string ModeloCoche { get; set; }

    // Constructor
    public Vendedor(string nombre, string apellidos, string dni, string direccion, string telefono, double salario, string matriculaCoche, string marcaCoche, string modeloCoche)
        : base(nombre, apellidos, dni, direccion, telefono, salario)
    {
        MatriculaCoche = matriculaCoche;
        MarcaCoche = marcaCoche;
        ModeloCoche = modeloCoche;
    }

    // Sobreescribe el método Imprimir para el vendedor
    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine($"Matrícula del coche: {MatriculaCoche}");
        Console.WriteLine($"Marca del coche: {MarcaCoche}");
        Console.WriteLine($"Modelo del coche: {ModeloCoche}");
    }

    // Sobreescribe el método IncrementarSalario para el vendedor
    public override void IncrementarSalario()
    {
        // Incremento del 10% anual
        Salario *= 1.10;
    }
}

public class JefeZona : Empleado
{
    // Atributos adicionales de JefeZona
    public string Despacho { get; set; }
    public Secretario SecretarioACargo { get; set; }
    public List<Vendedor> VendedoresACargo { get; set; }
    public string MatriculaCoche { get; set; }
    public string MarcaCoche { get; set; }
    public string ModeloCoche { get; set; }

    // Constructor
    public JefeZona(string nombre, string apellidos, string dni, string direccion, string telefono, double salario,
                    string despacho, Secretario secretario, string matriculaCoche, string marcaCoche, string modeloCoche)
        : base(nombre, apellidos, dni, direccion, telefono, salario)
    {
        Despacho = despacho;
        SecretarioACargo = secretario;
        MatriculaCoche = matriculaCoche;
        MarcaCoche = marcaCoche;
        ModeloCoche = modeloCoche;
        VendedoresACargo = new List<Vendedor>();
    }

    // Sobreescribe el método Imprimir para el jefe de zona
    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine($"Despacho: {Despacho}");
        Console.WriteLine("Secretario a cargo:");
        SecretarioACargo.Imprimir();
        Console.WriteLine($"Matrícula del coche: {MatriculaCoche}");
        Console.WriteLine($"Marca del coche: {MarcaCoche}");
        Console.WriteLine($"Modelo del coche: {ModeloCoche}");
        Console.WriteLine("Vendedores a cargo:");
        foreach (var vendedor in VendedoresACargo)
        {
            vendedor.Imprimir();
        }
    }

    // Método para cambiar el secretario a cargo
    public void CambiarSecretario(Secretario nuevoSecretario)
    {
        SecretarioACargo = nuevoSecretario;
    }

    // Método para cambiar el coche del jefe de zona
    public void CambiarCoche(string matricula, string marca, string modelo)
    {
        MatriculaCoche = matricula;
        MarcaCoche = marca;
        ModeloCoche = modelo;
    }

    // Método para dar de alta un nuevo vendedor en su zona
    public void DarAltaVendedor(Vendedor nuevoVendedor)
    {
        VendedoresACargo.Add(nuevoVendedor);
    }

    // Método para dar de baja un vendedor en su zona
    public void DarBajaVendedor(Vendedor vendedor)
    {
        VendedoresACargo.Remove(vendedor);
    }

    // Sobreescribe el método IncrementarSalario para el jefe de zona
    public override void IncrementarSalario()
    {
        // Incremento del 20% anual
        Salario *= 1.20;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un secretario
        Secretario secretario = new Secretario("Ana", "García", "12345678A", "Calle Principal 123", "987654321", 1500, "Despacho 1", "987654321");

        // Crear un jefe de zona
        JefeZona jefeZona = new JefeZona("Juan", "López", "87654321B", "Avenida Secundaria 456", "654321987", 3000, "Despacho 2", secretario, "1234ABC", "Seat", "Ibiza");

        // Crear vendedores
        Vendedor vendedor1 = new Vendedor("Pedro", "Gómez", "34567890C", "Calle Secundaria 789", "654987321", 2000, "5678DEF", "Renault", "Clio");
        Vendedor vendedor2 = new Vendedor("María", "Martínez", "45678901D", "Avenida Terciaria 1011", "321654987", 2000, "9012GHI", "Ford", "Fiesta");

        // Asignar vendedores al jefe de zona
        jefeZona.DarAltaVendedor(vendedor1);
        jefeZona.DarAltaVendedor(vendedor2);

        // Imprimir los datos del jefe de zona
        Console.WriteLine("Datos del Jefe de Zona:");
        jefeZona.Imprimir();

        // Incrementar salario del jefe de zona
        jefeZona.IncrementarSalario();

        // Imprimir los datos del jefe de zona después de incrementar salario
        Console.WriteLine("\nDatos del Jefe de Zona después de incrementar salario:");
        jefeZona.Imprimir();
    }
}
