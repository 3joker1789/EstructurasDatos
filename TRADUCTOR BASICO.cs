using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino / forma"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño/a"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto / tema"},
        {"government", "gobierno"},
        {"company", "empresa / compañía"}
    };

    static void Main(string[] args)
    {
        bool salir = false;
        
        while (!salir)
        {
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1":
                    TraducirFrase();
                    break;
                case "2":
                    AgregarPalabras();
                    break;
                case "0":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
            
            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase en español que desea traducir: ");
        string frase = Console.ReadLine();
        
        // Dividir la frase en palabras
        string[] palabras = frase.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        
        List<string> palabrasTraducidas = new List<string>();
        
        foreach (string palabra in palabras)
        {
            // Verificar si la palabra existe en el diccionario
            if (diccionario.ContainsKey(palabra.ToLower()))
            {
                // Si existe, obtener la traducción
                palabrasTraducidas.Add(diccionario[palabra.ToLower()]);
            }
            else
            {
                // Si no existe, mantener la palabra original
                palabrasTraducidas.Add(palabra);
            }
        }
        
        // Reconstruir la frase traducida
        string fraseTraducida = string.Join(" ", palabrasTraducidas);
        
        Console.WriteLine($"Frase traducida: {fraseTraducida}");
    }

    static void AgregarPalabras()
    {
        Console.Write("Ingrese la palabra en español: ");
        string espanol = Console.ReadLine().Trim();
        
        Console.Write("Ingrese la palabra en inglés: ");
        string ingles = Console.ReadLine().Trim();
        
        // Validar que no estén vacías
        if (string.IsNullOrEmpty(espanol) || string.IsNullOrEmpty(ingles))
        {
            Console.WriteLine("Error: Ambos campos son obligatorios.");
            return;
        }
        
        // Agregar al diccionario (clave: inglés, valor: español)
        diccionario[ingles] = espanol;
        
        Console.WriteLine($"Palabra agregada exitosamente: '{ingles}' -> '{espanol}'");
    }
}