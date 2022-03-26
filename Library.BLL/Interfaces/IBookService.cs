using System.Collections.Generic;
using System.Threading.Tasks;
using Library.BLL.Dto;

namespace Library.BLL.Interfaces
{
    public interface IBookService
    {
        Task<IList<BookDto>> GetAll();
        Task<BookDto> Get(int id);
        Task<BookDto> Add(BookDto model);
        Task<BookDto> Edit(BookDto model);
        Task<BookDto> Delete(int id);
    }
}
