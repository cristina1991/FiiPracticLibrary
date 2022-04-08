using AutoMapper;
using Library.BLL.Dto;
using Library.Data.Entities;

namespace Library.BLL.Mapper
{
    public class BorrowerProfile : Profile
    {
        public BorrowerProfile()
        {
            CreateMap<BorrowerDto, Borrower>().ReverseMap();
        }
    }
}
