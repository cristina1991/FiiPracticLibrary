using System.Collections.Generic;
using System.Threading.Tasks;
using Library.BLL.Dto;

namespace Library.BLL.Interfaces
{
    public interface IBorrowerService
    {
        Task<IList<BorrowerDto>> GetAll();
        Task<BorrowerDto> Get(int id);
        Task<string> Add(BorrowerDto model);
        Task<string> Edit(BorrowerDto model);
        Task<BorrowerDto> Delete(int id);
    }
}
