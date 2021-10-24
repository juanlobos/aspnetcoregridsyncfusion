using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoAlejandra.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El rut es necesario")]
        public string Rut { get; set; }
        [Required(ErrorMessage = "El nombre es necesario")]
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public bool Jubilado { get; set; }

        public Persona()
        {

        }
        public Persona(int id, DateTime fecha, bool estado, string nombre, string rut)
        {
            this.Id= id;
            this.Fecha = fecha;
            this.Jubilado = estado;
            this.Nombre = nombre;
            this.Rut = rut;
        }

        public static List<Persona> GetAllRecords()
        {
            var lista = new List<Persona>();
            if (lista.Count == 0)
            {
                lista.Add(new Persona(1, new DateTime(1995, 7, 2, 2, 3, 5), false, "VINET", "11111111-1"));
                lista.Add(new Persona(2, new DateTime(2012, 12, 25, 2, 3, 5), false, "ALFKI", "2222222-2"));
                lista.Add(new Persona(3, new DateTime(1953, 02, 18, 05, 2, 4), true, "TOMSP", "3333333-3"));
            }
            return lista;
        }
    }

    
}
