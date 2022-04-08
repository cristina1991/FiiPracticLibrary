using AutoMapper;
using Library.BLL.Dto;
using Library.Data.Entities;

namespace Library.BLL.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}
