using AutoMapper;
using Library.API.Models;
using Library.Data.Entities;

namespace Library.API.Mappers
{
    public class BorowerProfile : Profile
    {
        public BorowerProfile()
        {
            CreateMap<Borower, BorowerModel>().ReverseMap();
        }
    }
}
