using System.ComponentModel.DataAnnotations;

namespace Modelo.Dto
{
    public class FiltroReporteDto
    {
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true), Required(ErrorMessage = "requerida")]
        public DateTime FechaIni { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true), Required(ErrorMessage = "requerida")]
        public DateTime FechaFin { get; set; } = DateTime.Now;
    }
}
