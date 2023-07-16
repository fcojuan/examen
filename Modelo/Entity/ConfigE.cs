namespace Modelo.Entity
{
    public class ConfigE
    {
        public int Opc { get; set; } = 1;
        public int Id { get; set; } = 0;
        public decimal BonoPorEntrega { get; set; }
        public decimal ISR { get; set; }
        public decimal MontoExtraISR { get; set; }
        public decimal ISRExtra { get; set; }
        public decimal PorcentajeVales { get; set; }
    }
}
