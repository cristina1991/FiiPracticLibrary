using System.Collections.Generic;
using System.Threading.Tasks;
using Library.BLL.Dto;

namespace Library.BLL.Interfaces
{
    public interface IBookService
    {
        Task<IList<BookDto>> GetAll();
        Task<BookDto> Get(int id);
        Task<string> Add(BookDto model);
        Task<string> Edit(BookDto model);
        Task<BookDto> Delete(int id);
    }
}
