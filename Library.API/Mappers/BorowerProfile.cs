using AutoMapper;
using Library.API.Models;
using Library.BLL.Dto;
using Library.Data.Entities;

namespace Library.API.Mappers
{
    public class BorrowerProfile : Profile
    {
        public BorrowerProfile()
        {
            CreateMap<BorrowerDto, BorrowerModel>().ReverseMap();
            CreateMap<Borrower, BorrowerModel>().ReverseMap();
        }
    }
}
