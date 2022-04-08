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
    public class BorrowerService : IBorrowerService
    {
        private readonly IRepository<Borrower> _repository;
        private readonly IMapper _mapper;

        public BorrowerService(IRepository<Borrower> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<BorrowerDto>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IList<BorrowerDto>>(entities);
        }

        public async Task<BorrowerDto> Get(int id)
        {
            var entities = await _repository.GetAllAsync();
            var entityById = entities.SingleOrDefault(e => e.Id == id);
            var mapped = _mapper.Map<BorrowerDto>(entityById);

            return mapped;
        }

        public async Task<BorrowerDto> Add(BorrowerDto model)
        {
            var mappedBorrower = _mapper.Map<BorrowerDto, Borrower>(model);
            var addedBorrower = await _repository.AddAsync(mappedBorrower);

            return _mapper.Map<BorrowerDto>(addedBorrower);
        }

        public async Task<bool> Edit(BorrowerDto model)
        {
            if(await _repository.ExistsAsync(x => x.Id == model.Id))
            {
                var mappedBorrower = _mapper.Map<BorrowerDto, Borrower>(model);
                var response = await _repository.UpdateAsync(mappedBorrower);

                return response;
            }
            return false;
        }

        public async Task<BorrowerDto> Delete(int id)
        {
            if (await _repository.ExistsAsync(x => x.Id == id))
            {
                var borrower = await _repository.SingleOrDefaultAsync(x => x.Id == id);

                var response = await _repository.DeleteAsync(borrower);
                return response ? _mapper.Map<BorrowerDto>(borrower) : null;

            }
            return null;
        }
    }
}