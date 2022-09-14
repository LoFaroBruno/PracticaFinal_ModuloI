using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFIPPersonasWebApp.Models
{
    public class CodActividad
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        public string Descripcion { get; set; }
        [Required, Range(000, 99999999)]
        public string Codigo { get; set; }
    }
}