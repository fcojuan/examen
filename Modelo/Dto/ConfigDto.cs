using System.ComponentModel.DataAnnotations;

namespace Modelo.Dto
{
    public class ConfigDto
    {
        [Key]
        [Display(Name = "Id")]
        public string Id { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:#,###,###0.00}")]
        public decimal BonoPorEntrega { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,###,###0.00}")]
        public decimal ISR { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,###,###0.00}")]
        public decimal MontoExtraISR { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,###,###0.00}")]
        public decimal ISRExtra { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,###,###0.00}")]
        public decimal PorcentajeVales { get; set; }
    }
}
