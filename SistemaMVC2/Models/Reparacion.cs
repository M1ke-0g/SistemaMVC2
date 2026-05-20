using System;

namespace SistemaMVC2.Models
{
    public class Reparacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public decimal Coste { get; set; }
        public string Garantia { get; set; }
    }
}
