using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly IRepository<Book> _BookRepository;
        private readonly IRepository<Borrower> _BorrowerRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> BookRepository, IRepository<Borrower> BorrowerRepository,
            IMapper mapper)
        {
            _BorrowerRepository = BorrowerRepository;
            _BookRepository = BookRepository;
            _mapper = mapper;
        }
        public async Task<IList<BookDto>> GetAll()
        {
            var entities = await _BookRepository.GetAllAsync();
            return _mapper.Map<IList<BookDto>>(entities);  
        }

        public async Task<BookDto> Get(int id)
        {
            var entities = await _BookRepository.GetAllAsync();
            var entityById = entities.SingleOrDefault(e => e.Id == id);
            var mapped = _mapper.Map<BookDto>(entityById);

            return mapped;
        }

        public async Task<BookDto> Add(BookDto model)
        {
            
            try
            {
                var mappedBook = _mapper.Map<BookDto, Book>(model);
                var addedBook = await _BookRepository.AddAsync(mappedBook);
                return _mapper.Map<Book, BookDto>(addedBook);
            }
            catch
            {
                return null;
            }
        }
        
        public async Task<bool> Edit(BookDto model)
        {
            var mappedBook = _mapper.Map<BookDto, Book>(model);
            var response = await _BookRepository.UpdateAsync(mappedBook);
            return response;
        }

        public async Task<BookDto> Delete(int id)
        {
            if (await _BookRepository.ExistsAsync(x => x.Id == id))
            {
                var book = await _BookRepository.SingleOrDefaultAsync(x => x.Id == id);
                
                var response = await _BookRepository.DeleteAsync(book);
                return response ? _mapper.Map<BookDto>(book) : null;
               
            }
            return null;
        }
    }
}
