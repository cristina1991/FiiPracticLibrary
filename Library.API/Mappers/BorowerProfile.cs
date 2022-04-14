using AutoMapper;
using Library.API.Models;
using Library.BLL.Dto;

namespace Library.API.Mappers
{
    public class BorowerProfile : Profile
    {
        public BorowerProfile()
        {
            CreateMap<BorrowerDto, BorrowerModel>().ReverseMap();
            CreateMap<BorrowerModel, BorrowerDto>().ReverseMap();
        }
    }
}
