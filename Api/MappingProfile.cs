using Api.DTO;
using Api.Entities;
using AutoMapper;

namespace Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ticket, TicketDto>();
        CreateMap<AnimalDto, Animal>();
        CreateMap<CaretakerDto, Caretaker>();
    }
}
