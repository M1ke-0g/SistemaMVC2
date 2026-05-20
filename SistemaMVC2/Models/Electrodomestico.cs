using System;

namespace SistemaMVC2.Models
{
    public class Electrodomestico
    {
        public int ElectrodomesticoId { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }
    }
}
