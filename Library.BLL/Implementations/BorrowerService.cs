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
        private readonly IRepository<Borrower> _BorrowerRepository;
        private readonly IRepository<Book> _BookRepository;
        private readonly IMapper _mapper;

        public BorrowerService(IRepository<Borrower> BorrowerRepository, IRepository<Book> BookRepository
            ,IMapper mapper)
        {
            _BookRepository = BookRepository;
            _BorrowerRepository = BorrowerRepository;
            _mapper = mapper;
        }

        public async Task<IList<BorrowerDto>> GetAll()
        {
            var entities = await _BorrowerRepository.GetAllAsync();
            return _mapper.Map<IList<BorrowerDto>>(entities);    
        }

        public async Task<BorrowerDto> Get(int id)
        { 
            var entities = await _BorrowerRepository.GetAllAsync();
            var entityById = entities.SingleOrDefault(e => e.Id == id);
            var mapped = _mapper.Map<BorrowerDto>(entityById);

            return mapped;
        }

        public async Task<BorrowerDto> Add(BorrowerDto model)
        {
            try
            {
                
                var mappedBorrower = _mapper.Map<BorrowerDto, Borrower>(model);

                //copie la cartile introduse de borrower in lista sa
                var bookList = new List<Book>();

                foreach(var item in mappedBorrower.Books)
                {
                    bookList.Add(item);
                }

                //in functia create borrower se creaza si cartile introduse in aceasta lista, deci
                //le sterg lista pentru a le schimba id-ul borrower manual mai jos
                mappedBorrower.Books = null;

                var addedBorrower = await _BorrowerRepository.AddAsync(mappedBorrower);

                if (addedBorrower != null)
                {
                    foreach (var item in bookList)
                    {
                        item.BorrowerId = addedBorrower.Id;
                        await _BookRepository.UpdateAsync(item);
                    }
                    
                }

                return _mapper.Map<Borrower, BorrowerDto>(addedBorrower);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Edit(BorrowerDto model)
        {
            var mappedBorrower = _mapper.Map<BorrowerDto, Borrower>(model);

            var response = await _BorrowerRepository.UpdateAsync(mappedBorrower);
            return response;
        }

        public async Task<BorrowerDto> Delete(int id)
        {
            if (await _BorrowerRepository.ExistsAsync(x => x.Id == id))
            {
                var book = await _BorrowerRepository.SingleOrDefaultAsync(x => x.Id == id);

                var response = await _BorrowerRepository.DeleteAsync(book);
                return response ? _mapper.Map<BorrowerDto>(book) : null;

            }
            return null;
        }


    }
}
