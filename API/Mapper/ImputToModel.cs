using AutoMapper;
using Genius.API.Input;
using Genius.Infraestructure.Models;

namespace Genius.API.Mapper;

public class ImputToModel: Profile
{public ImputToModel()
    {
        CreateMap<DriverInput, Driver>();
    }
}