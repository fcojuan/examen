using System.ComponentModel.DataAnnotations;

namespace Modelo.Dto
{
    public class PuestosDto
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [StringLength(80, ErrorMessage = "Maximo 80 Caracteres"), Required(ErrorMessage = "requerida")]
        public string Nombre { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:#,###,###0.00}")]
        public decimal BonoHora { get; set; }
        public string Pagar { get; set; } = "false";
        public string Estatus { get; set; } = string.Empty;
    }
}
