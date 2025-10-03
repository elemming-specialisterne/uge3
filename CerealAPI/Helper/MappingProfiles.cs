using AutoMapper;
using CerealAPI.DTO;
using CerealAPI.Model;

namespace CerealAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cereal, CerealDTO>();
            CreateMap<CerealDTO, Cereal>();
            CreateMap<Manufacturer, ManufacturerDTO>();
            CreateMap<ManufacturerDTO, Manufacturer>();
            CreateMap<Model.Type, TypeDTO>();
            CreateMap<TypeDTO, Model.Type>();
        }
    }
}