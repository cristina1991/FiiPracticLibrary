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
        private readonly IRepository<Book> _BookRepository;
        private readonly IMapper _mapper;

        public BorrowerService(IRepository<Borrower> repository, IRepository<Book> BookRepository
            ,IMapper mapper)
        {
            _BookRepository = BookRepository;
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

        /// <summary>
        /// This function inserts a borrower into the database. Errors that may occur:
        /// Error1 - The books entered do not correspond to the database!
        /// Error2 - An introduced book has already been borrowed!
        /// Error3 - Strange error occurred! 
        /// </summary>
        public async Task<string> Add(BorrowerDto model)
        {
            try
            {
                var mappedBorrower = _mapper.Map<BorrowerDto, Borrower>(model);

                for (int i = 0; i < mappedBorrower.Books.Count; i++)
                {
                    Book book = new Book();
                    if (!await _BookRepository.ExistsAsync(x => x == mappedBorrower.Books[i]))
                    {
                        return "Error1";
                    }
                    if (mappedBorrower.Books[i].BorrowerId != 0)
                    {
                        return "Error2";
                    }
                }

                var addedBorrower = await _repository.AddAsync(mappedBorrower);

                return (addedBorrower!=null) ? "Success" : "Error3";
            }
            catch
            {
                return "Error3";
            }
        }

        /// <summary>
        /// This function edits a borrower into the database. Errors that may occur:
        /// Error1 - Borrower not found or not created!
        /// Error2 - The books entered do not correspond to the database!
        /// Error3 - An introduced book has already been borrowed!
        /// Error4 - Strange error occurred! 
        /// </summary>
        public async Task<string> Edit(BorrowerDto model)
        {
            try
            {
                if (!await _repository.ExistsAsync(x => x.Id == model.Id))
                {
                    return "Error1";
                }
                var mappedBorrower = _mapper.Map<BorrowerDto, Borrower>(model);

                for (int i = 0; i < mappedBorrower.Books.Count; i++)
                {
                    Book book = new Book();
                    if (!await _BookRepository.ExistsAsync(x => x == mappedBorrower.Books[i]))
                    {
                        return "Error2";
                    }
                    if (mappedBorrower.Books[i].BorrowerId!=0)
                    {
                        return "Error3";
                    }
                }

            
                var response = await _repository.UpdateAsync(mappedBorrower);

                return (response) ? "Success" : "Error4";
            }
            catch
            {
                return "Error4";
            }
            

        }

        public async Task<BorrowerDto> Delete(int id)
        {
            if (await _repository.ExistsAsync(x => x.Id == id))
            {
                var book = await _repository.SingleOrDefaultAsync(x => x.Id == id);

                var response = await _repository.DeleteAsync(book);
                return response ? _mapper.Map<BorrowerDto>(book) : null;

            }
            return null;
        }


    }
}
