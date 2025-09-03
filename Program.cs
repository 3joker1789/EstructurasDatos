using System;
using System.Collections.Generic;

namespace EstructurasDatos
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TRADUCTOR BÁSICO");
            Console.WriteLine("================\n");
            
            var traductor = new Traductor();
            traductor.Inicializar();
            
            while (true)
            {
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1. Agregar traducción");
                Console.WriteLine("2. Traducir palabra");
                Console.WriteLine("3. Mostrar todas las palabras");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                
                var opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        Console.Write("Palabra en español: ");
                        var esp = Console.ReadLine();
                        Console.Write("Palabra en inglés: ");
                        var ing = Console.ReadLine();
                        traductor.AgregarTraduccion(esp, ing);
                        break;
                    case "2":
                        Console.Write("Palabra a traducir: ");
                        var palabra = Console.ReadLine();
                        var traduccion = traductor.Traducir(palabra);
                        Console.WriteLine($"Traducción: {traduccion}");
                        break;
                    case "3":
                        traductor.MostrarTodas();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }
    }
}