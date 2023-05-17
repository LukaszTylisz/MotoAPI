using AutoMapper;
using MotoAPI.Entitites;
using MotoAPI.Models;

namespace MotoAPI;

public class MotoMappingProfile : Profile
{
    public MotoMappingProfile()
    {
        CreateMap<Moto, MotoDto>()
            .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
            .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
            .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

        CreateMap<Car, CarDto>();

        CreateMap<CreateMotoDto, Moto>()
            .ForMember(m => m.Address,
                c => c.MapFrom(dto => new Address()
                    { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));

        CreateMap<CreateCarDto, Car>();
    }
}