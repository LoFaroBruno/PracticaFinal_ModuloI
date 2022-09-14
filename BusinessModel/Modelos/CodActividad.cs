using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel.Modelos
{
    public class CodActividad
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
    }
}
