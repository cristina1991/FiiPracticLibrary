using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.Dto;
using Library.BLL.Interfaces;
using Library.Data.Entities;
using Library.Data.Interfaces;

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
            //verify if borrower exists in database!!!
            var mappedBook = _mapper.Map<BookDto, Book>(model);
            var addedBook = await _repository.AddAsync(mappedBook);

            return _mapper.Map<BookDto>(addedBook);

        }
        public async Task<bool> Edit(BookDto model)
        {
            if (await _repository.ExistsAsync(x => x.Id == model.Id))
            {
                var mappedBook = _mapper.Map<BookDto, Book>(model);
                var response = await _repository.UpdateAsync(mappedBook);

                return response;
            }
            return false;
        }

        public async Task<BookDto> Delete(int id)
        {
            if (await _repository.ExistsAsync(x => x.Id == id))
            {
                var book = await _repository.SingleOrDefaultAsync(x => x.Id == id);

                var response = await _repository.DeleteAsync(book);
                return response ? _mapper.Map<BookDto>(book) : null;

            }
            return null;
        }
    }
}