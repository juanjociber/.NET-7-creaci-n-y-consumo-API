using API_NET7.Modelos;
using API_NET7.Modelos.DTO;
using AutoMapper;

namespace API_NET7
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {

            CreateMap<Villa, VillaDTO>().ReverseMap();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa,VillaUpdateDTO>().ReverseMap();

        }
    }
}
