using System.ComponentModel.DataAnnotations;

namespace Modelo.Entity
{
    public class PuestoE
    {
        public int Opc { get; set; } = 1;
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public decimal BonoHora { get; set; }
        public string Pagar{ get; set; } = string.Empty;
    }
}
