using Notebook.App.Domain.Entities;
using Notebook.App.Models;
using AutoMapper;

namespace Notebook.App;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<User, UserRequestModel>().ReverseMap();
        
        CreateMap<User, UserResponseModel>().ReverseMap();
        
        CreateMap<Phone, PhoneResponseModel>().ReverseMap();
        
        CreateMap<Phone, PhoneRequestModel>().ReverseMap();
    }
}