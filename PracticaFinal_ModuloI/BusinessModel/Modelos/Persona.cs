using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel.Modelos
{
    public class Persona
    {
        public int ID { get; set; }
        public int CodActividadId { get; set; }
        public CodActividad CodActividad { get; set; }
        public string ClaveTributaria { get; set; }
    }
}
