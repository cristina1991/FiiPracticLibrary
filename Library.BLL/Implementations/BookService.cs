using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Dto;
using Library.BLL.Interfaces;

namespace Library.BLL.Implementations
{
    public class BookService : IBookService
    {
        public BookService()
        {
            
        }
        public async Task<IList<BookDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BookDto> Get(int id)
        {
            throw new NotImplementedException();
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
