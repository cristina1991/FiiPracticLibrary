using AutoMapper;
using Library.API.Models;
using Library.Data.Models;

namespace Library.API.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookModel>()
                .ForMember(dest=> dest.Id, opt=>opt.Ignore())
                .ForMember(dest => dest.BookNameAndYear, opt => opt.MapFrom(src => $"{src.Name} {src.Year}")).ReverseMap();
        }
    }
}
