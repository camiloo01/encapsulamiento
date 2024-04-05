using System;
using System.Collections.Generic;

// Clase Empleado
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
        // 5% 
        Salario *= 1.05;
    }
}

// Clase Secretario
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

    // Método para imprimir los datos del secretario
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

// Clase Vendedor
public class Vendedor : Empleado
{
    // Atributos adicionales de Vendedor
    public string MatriculaCoche { get; set; }
    public string MarcaCoche { get; set; }
    public string ModeloCoche { get; set; }
    public string TelefonoMovil { get; set; }
    public string AreaVenta { get; set; }
    public List<string> ListaClientes { get; set; }
    public double PorcentajeComision { get; set; }

    // Constructor
    public Vendedor(string nombre, string apellidos, string dni, string direccion, string telefono, double salario,
                    string matriculaCoche, string marcaCoche, string modeloCoche, string telefonoMovil, string areaVenta, double porcentajeComision)
        : base(nombre, apellidos, dni, direccion, telefono, salario)
    {
        MatriculaCoche = matriculaCoche;
        MarcaCoche = marcaCoche;
        ModeloCoche = modeloCoche;
        TelefonoMovil = telefonoMovil;
        AreaVenta = areaVenta;
        PorcentajeComision = porcentajeComision;
        ListaClientes = new List<string>();
    }

    // Método para imprimir los datos del vendedor
    public override void Imprimir()
    {
        base.Imprimir();
        Console.WriteLine($"Matrícula del coche: {MatriculaCoche}");
        Console.WriteLine($"Marca del coche: {MarcaCoche}");
        Console.WriteLine($"Modelo del coche: {ModeloCoche}");
        Console.WriteLine($"Teléfono móvil: {TelefonoMovil}");
        Console.WriteLine($"Área de venta: {AreaVenta}");
        Console.WriteLine($"Porcentaje de comisión: {PorcentajeComision}%");
    }

    // Método para dar de alta un nuevo cliente
    public void DarAltaCliente(string cliente)
    {
        ListaClientes.Add(cliente);
    }

    // Método para dar de baja un cliente
    public void DarBajaCliente(string cliente)
    {
        ListaClientes.Remove(cliente);
    }

    // Método para cambiar el coche del vendedor
    public void CambiarCoche(string matricula, string marca, string modelo)
    {
        MatriculaCoche = matricula;
        MarcaCoche = marca;
        ModeloCoche = modelo;
    }

    // Sobreescribe el método IncrementarSalario para el vendedor
    public override void IncrementarSalario()
    {
        // Incremento del 10% anual
        Salario *= 1.10;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ejemplo de uso de las clases

        // Crear un secretario
        Secretario secretario = new Secretario("Juan", "López", "12345678A", "Calle Principal 123", "987654321", 1500, "Despacho 1", "987654321");

        // Crear un vendedor
        Vendedor vendedor = new Vendedor("Pedro", "Gómez", "87654321B", "Avenida Secundaria 456", "654321987", 2000, "1234ABC", "Seat", "Ibiza", "678123456", "Zona Norte", 5);

        // Imprimir los datos del secretario y el vendedor
        Console.WriteLine("Datos del Secretario:");
        secretario.Imprimir();
        Console.WriteLine("\nDatos del Vendedor:");
        vendedor.Imprimir();
    }
}

