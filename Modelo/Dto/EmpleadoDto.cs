using System.ComponentModel.DataAnnotations;

namespace Modelo.Dto
{
    public class EmpleadoDTO
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "requerida")]
        public string Codigo { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres"), Required(ErrorMessage = "requerida")]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(80, ErrorMessage = "Maximo 80 Caracteres"), Required(ErrorMessage = "requerida")]
        public string ApellidoP { get; set; } = string.Empty;

        [MaxLength(80,ErrorMessage ="Maximo 80 Caracteres")]
        public string ApellidoM { get; set; } = string.Empty;

        [Required(ErrorMessage = "requerida")]
        public string IdRol { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:#,###,###0.00}")]
        public Decimal SueldoHora { get; set; }

        [DisplayFormat(DataFormatString = "{0:###0}")]
        public int JornadaLaboral { get; set; }

        [DisplayFormat(DataFormatString = "{0:###0}")]
        public int DiasTrabajo { get; set; }
        public string Estatus { get; set; } = string.Empty;
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + ApellidoP + " " + ApellidoM;
            }
        }
    }
}
