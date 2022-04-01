using System;
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
            var toAddEntity = _mapper.Map<Borrower>(model);
            var returnedEntity = await _repository.AddAsync(toAddEntity);

            return _mapper.Map<BorrowerDto>(returnedEntity);
        }

        public async Task<BorrowerDto> Edit(BorrowerDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<BorrowerDto> Delete(int id)
        {
            var entities = await _repository.GetAllAsync();
            var toDeleteEntity = entities.SingleOrDefault(e=>e.Id== id);

            bool success= await _repository.DeleteAsync(toDeleteEntity);

            if(success)
            return _mapper.Map<BorrowerDto>(toDeleteEntity);

            else
            {
                throw new Exception("The borrower couldn't be found.");
            }
        }
    }
}
