
using AutoMapper;
using Genius.Infraestructure.Models;
using Genius.API.Response;

namespace Genius.API.Mapper;

public class ModelToResponse: Profile

{

    public ModelToResponse()
    {
        CreateMap<Driver, DriverResponse>();
        CreateMap<Car, CarResponse>();

    }
}

