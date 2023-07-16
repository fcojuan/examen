namespace Modelo.Dto
{
    public class NominaDto
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public int Entregas { get; set; }
        public DateTime Fecha { get; set; }
        public int DiasTrabajo { get; set; }
        public decimal SueldoHora { get; set; }
        public int JornadaLaboral { get; set; }
        public decimal BonoPorEntrega { get; set; }
        public decimal ISR { get; set; }
        public decimal MontoISR { get; set; }
        public decimal ExtraISR { get; set; }
        public decimal Vales { get; set; }
        public decimal BonoxHora { get; set; }
        public decimal SueldoTotal { get; set; }
        public decimal BonoEntregaTotal { get; set; }
        public decimal BonoHoraTotal { get; set; }
        public decimal ValesTotal { get; set; }
        public decimal SumaTotal { get; set; }
        public decimal ISR9 { get; set; }
        public decimal ISRMASDesc { get; set; }
        public decimal GranTotal { get; set; }
    }
}
