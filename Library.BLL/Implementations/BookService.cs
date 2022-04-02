using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.Dto;
using Library.BLL.Interfaces;
using Library.Data.Entities;
using Library.Data.Interfaces;
using System.Linq;
namespace Library.BLL.Implementations
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;
        public BookService(IRepository<Book> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IList<BookDto>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IList<BookDto>>(entities);
        }

        public async Task<BookDto> Get(int id)
        {
            var entities = await _repository.GetAllAsync();
            var entityById = entities.SingleOrDefault(e => e.Id == id);
            var mapped = _mapper.Map<BookDto>(entityById);

            return mapped;
        }

        public async Task<BookDto> Add(BookDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDto> Edit(BookDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDto> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
