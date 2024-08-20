using AutoMapper;
using Conference.Domain.Entities;
using ConferenceApi.Models;

namespace ConferenceApi.Mappings;

public class WorkshopProfile : Profile
{
    public WorkshopProfile()
    {
        CreateMap<Workshop, WorkshopModel>();
    }
}
