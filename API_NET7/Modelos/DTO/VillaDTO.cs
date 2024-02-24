
using System.ComponentModel.DataAnnotations;

namespace API_NET7.Modelos.DTO
{
    public class VillaDTO
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
    }
}
