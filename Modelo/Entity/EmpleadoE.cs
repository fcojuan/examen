using System.ComponentModel.DataAnnotations;

namespace Modelo.Entity
{
    public class EmpleadoE
    {
        public int Opc { get; set; } = 1;
        public int Id { get; set; } = 0;
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoP { get; set; } = string.Empty;
        public string ApellidoM { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public Decimal SueldoHora { get; set; }
        public int JornadaLaboral { get; set; }
        public int DiasTrabajo { get; set; }
    }
}
