using AutoMapper;
using Supermarket.API.Resources;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile(){
            CreateMap<SaveCategoryResource, Category>(); 
        }
    }
}