using API_NET7.Modelos.DTO;

namespace API_NET7.Datos
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO{Id=1, Nombre="Vista a la Piscina",Ocupantes=3,MetrosCuadrados=50 },
            new VillaDTO{Id=2, Nombre="Vista a la Playa",Ocupantes=4,MetrosCuadrados=80}
        };
    }
}
