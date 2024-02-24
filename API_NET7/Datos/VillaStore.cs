using API_NET7.Modelos.DTO;

namespace API_NET7.Datos
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO{Id=1, Nombre="Vista a la Piscina" },
            new VillaDTO{Id=2, Nombre="Vista a la Playa"}
        };
    }
}
