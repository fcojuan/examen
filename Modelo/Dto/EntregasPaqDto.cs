using System.ComponentModel.DataAnnotations;

namespace Modelo.Dto
{
    public class EntregasPaqDto
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "requerida")]
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoP { get; set; } = string.Empty;
        public string ApellidoM { get; set; } = string.Empty;
        public string IdRol { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:###0}")]
        public int PaqEntregado { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true), Required(ErrorMessage = "requerida")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + ApellidoP + " " + ApellidoM;
            }
        }

    }
}
