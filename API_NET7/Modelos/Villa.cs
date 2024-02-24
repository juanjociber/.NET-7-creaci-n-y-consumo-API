using System.ComponentModel.DataAnnotations;

namespace API_NET7.Modelos
{
    public class Villa
    {
        public int Id { get; set; }
 
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
