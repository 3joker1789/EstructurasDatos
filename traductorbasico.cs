using System;
using System.Collections.Generic;

namespace EstructurasDatos
{
    partial class Program
    {
        class Traductor
        {
            private Dictionary<string, string> palabras;
            
            public Traductor()
            {
                palabras = new Dictionary<string, string>();
            }
            
            public void Inicializar()
            {
                // Algunas palabras iniciales
                AgregarTraduccion("hola", "hello");
                AgregarTraduccion("adiós", "goodbye");
                AgregarTraduccion("gato", "cat");
                AgregarTraduccion("perro", "dog");
            }
            
            public void AgregarTraduccion(string espanol, string ingles)
            {
                if (!string.IsNullOrWhiteSpace(espanol) && !string.IsNullOrWhiteSpace(ingles))
                {
                    palabras[espanol.ToLower()] = ingles.ToLower();
                    Console.WriteLine($"Traducción agregada: {espanol} -> {ingles}");
                }
                else
                {
                    Console.WriteLine("Error: Las palabras no pueden estar vacías");
                }
            }
            
            public string Traducir(string palabra)
            {
                if (string.IsNullOrWhiteSpace(palabra))
                    return "Palabra no válida";
                
                palabra = palabra.ToLower();
                
                if (palabras.ContainsKey(palabra))
                    return palabras[palabra];
                else
                    return "Palabra no encontrada en el diccionario";
            }
            
            public void MostrarTodas()
            {
                Console.WriteLine("\nDiccionario completo:");
                foreach (var par in palabras)
                {
                    Console.WriteLine($"{par.Key} -> {par.Value}");
                }
            }
        }
    }
}