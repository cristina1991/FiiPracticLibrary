using System.Threading.Tasks;
using System.Collections.Generic;
using Library.Data.Entities;
using Library.BLL.Dto;

namespace Library.BLL.Interfaces
{
    public interface IBorrowerValidations
    {
        Task<bool> ExistsAllBooksInDatabase(BorrowerDto model);
        public bool AllBooksAreAvailable(BorrowerDto model);
        Task<bool> IsBorrowerIdValid(int id);
    }
}
