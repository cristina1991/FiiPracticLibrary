using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IBookValidations
    {
        Task<bool> IsBorrowerIdValid(int id);
        Task<bool> ExistsBookById(int id);
    }
}
