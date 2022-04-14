using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.Dto;
using Library.BLL.Interfaces;
using Library.Data.Entities;
using Library.Data.Interfaces;

namespace Library.BLL.Implementations
{
    public class BorrowerValidations : IBorrowerValidations
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _BookRepository;
        private readonly IRepository<Borrower> _BorrowerRepository;

        public BorrowerValidations(IMapper mapper, IRepository<Book> BookRepository, IRepository<Borrower> BorrowerRepository)
        {
            _mapper = mapper;
            _BorrowerRepository = BorrowerRepository;
            _BookRepository = BookRepository;
        }

        public async Task<bool> ExistsAllBooksInDatabase(BorrowerDto model)
        {
            var mappedBorrower = _mapper.Map<BorrowerDto, Borrower>(model);

            for (int i = 0; i < mappedBorrower.Books.Count; i++)
            {
                if (!await _BookRepository.ExistsAsync(x => x.Id == mappedBorrower.Books[i].Id && x.Name == mappedBorrower.Books[i].Name && x.Year == mappedBorrower.Books[i].Year && x.Author == mappedBorrower.Books[i].Author && x.Description == mappedBorrower.Books[i].Description && x.BorrowerId == mappedBorrower.Books[i].BorrowerId))
                {
                    return false;
                }

            }

            return true;
        }

        public bool AllBooksAreAvailable(BorrowerDto model)
        {
            var mappedBorrower = _mapper.Map<BorrowerDto, Borrower>(model);

            for (int i = 0; i < mappedBorrower.Books.Count; i++)
            {
                if (mappedBorrower.Books[i].BorrowerId != 0)
                {
                    return false;
                }

            }

            return true;
        }
        public async Task<bool> IsBorrowerIdValid(int id)
        {
            if (id != 0 && !await _BorrowerRepository.ExistsAsync(x => x.Id == id))
            {
                return false;
            }
            return true;
        }
    }
}
