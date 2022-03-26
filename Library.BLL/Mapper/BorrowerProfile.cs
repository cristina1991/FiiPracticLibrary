using System.Linq;
using AutoMapper;
using Library.BLL.Dto;
using Library.Data.Entities;

namespace Library.BLL.Mapper
{
    public class BorrowerProfile : Profile
    {
        public BorrowerProfile()
        {
        //    CreateMap<Borrower,BorrowerDto>()
        //        .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books.ToList()))
        //        .ReverseMap();

            CreateMap<BorrowerDto, Borrower>()
                .ReverseMap();
        }
    }
}
