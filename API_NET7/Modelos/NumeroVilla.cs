using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_NET7.Modelos
{
    public class NumeroVilla
    {
        //Permite ingresar al usuario que asigne el número
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNro { get;set; }

        [Required]
        public int VillaId { get; set;}

        [ForeignKey("VillaId")]
        public Villa Villa { get; set;}

        public string DetalleEspecial { get; set;}
        public DateTime FechaCreacion { get; set;}
        public DateTime FechaActualizacion { get; set;}

    }
}
