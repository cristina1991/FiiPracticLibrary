using AutoMapper;
using Library.API.Models;
using Library.BLL.Dto;
using Library.Data.Entities;

namespace Library.API.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, BookModel>().ReverseMap();
            CreateMap<Book, BookModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.BookNameAndYear, opt => opt.MapFrom(src => $"{src.Name} {src.Year}")).ReverseMap();
        }
    }
}
