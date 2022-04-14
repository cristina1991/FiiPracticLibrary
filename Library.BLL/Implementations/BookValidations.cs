
using System.Threading.Tasks;
using Library.BLL.Interfaces;
using Library.Data.Entities;
using Library.Data.Interfaces;

namespace Library.BLL.Implementations
{
    public class BookValidations : IBookValidations
    {
        private readonly IRepository<Book> _BookRepository;
        private readonly IRepository<Borrower> _BorrowerRepository;

        public BookValidations(IRepository<Book> BookRepository, IRepository<Borrower> BorrowerRepository)
        {
            _BorrowerRepository = BorrowerRepository;
            _BookRepository = BookRepository;
        }

        public async Task<bool> IsBorrowerIdValid(int id)
        {
            if (id != 0 && !await _BorrowerRepository.ExistsAsync(x => x.Id == id))
            {
                return false;
            }
            return true;
        }
        public async Task<bool> ExistsBookById(int id)
        {
            if (await _BookRepository.ExistsAsync(x => x.Id == id))
            {
                return true;
            }
            return false;
        }
    }
}
