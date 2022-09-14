using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel.Modelos
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CodActividadId { get; set; }
        [ForeignKey("CodActividadId")]
        public CodActividad CodActividad { get; set; }
        [Required, Range(11111111111, 99999999999)]
        public string ClaveTributaria { get; set; }
    }
}
