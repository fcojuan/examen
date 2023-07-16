namespace Modelo.Entity
{
    public class EntregasPaqE
    {
        public int Opc { get; set; } = 1;
        public int Id { get; set; } = 0;
        public string Codigo { get; set; } = string.Empty;
        public int PaqEntregado { get; set; }
        public string Fecha { get; set; } = string.Empty;
    }
}
