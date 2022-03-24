using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documentos.Application.DTOs
{
    public class DocumentoDTO
    {
        [Required(ErrorMessage = "Codigo é obrigatorio")]
        [MinLength(3)]
        [MaxLength(2000)]
        [DisplayName("Codigo")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatorio")]
        [MinLength(3)]
        [MaxLength(2000)]
        [DisplayName("Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Revisao é obrigatorio")]
        [MinLength(1)]
        [MaxLength(1)]
        [DisplayName("Revisao")]
        public string Revisao { get; set; }

        [Required(ErrorMessage = "DataPlanejada é obrigatorio")]
        [DisplayName("DataPlanejada")]
        public DateTime DataPlanejada { get; set; }

        [Required(ErrorMessage = "Valor é obrigatorio")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        public decimal Valor { get; set; }
    }
}
