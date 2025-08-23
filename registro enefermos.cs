using System;
using System.Collections.Generic;
using System.Linq;

// Código principal (top-level statements) - debe estar al principio del archivo
var random = new Random();
var totalCiudadanos = 500;

var todosCiudadanos = Enumerable.Range(1, totalCiudadanos)
                                .Select(id => new Ciudadano(id))
                                .ToList();

var shuffled = todosCiudadanos.OrderBy(c => random.Next()).ToList();

var pfizerCiudadanos = new HashSet<Ciudadano>(shuffled.Take(75));
var astraZenecaCiudadanos = new HashSet<Ciudadano>(shuffled.Skip(75).Take(75));

// Operaciones de conjuntos
var noVacunados = new HashSet<Ciudadano>(todosCiudadanos);
noVacunados.ExceptWith(pfizerCiudadanos);
noVacunados.ExceptWith(astraZenecaCiudadanos);

var ambasDosis = new HashSet<Ciudadano>(pfizerCiudadanos);
ambasDosis.IntersectWith(astraZenecaCiudadanos);

var soloPfizer = new HashSet<Ciudadano>(pfizerCiudadanos);
soloPfizer.ExceptWith(astraZenecaCiudadanos);

var soloAstraZeneca = new HashSet<Ciudadano>(astraZenecaCiudadanos);
soloAstraZeneca.ExceptWith(pfizerCiudadanos);

// Mostrar resultados
Console.WriteLine("Ciudadanos no vacunados:");
foreach (var ciudadano in noVacunados)
    Console.WriteLine(ciudadano.Nombre);

Console.WriteLine("\nCiudadanos con ambas dosis:");
foreach (var ciudadano in ambasDosis)
    Console.WriteLine(ciudadano.Nombre);

Console.WriteLine("\nCiudadanos solo con Pfizer:");
foreach (var ciudadano in soloPfizer)
    Console.WriteLine(ciudadano.Nombre);

Console.WriteLine("\nCiudadanos solo con AstraZeneca:");
foreach (var ciudadano in soloAstraZeneca)
    Console.WriteLine(ciudadano.Nombre);

// Define la clase Ciudadano después de las instrucciones de nivel superior
class Ciudadano
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Ciudadano(int id)
    {
        Id = id;
        Nombre = $"Ciudadano {id}";
    }
}