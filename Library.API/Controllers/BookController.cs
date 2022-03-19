using Library.API.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Library.Data.MockData;
using AutoMapper;
using Library.API.Models;
using Library.Data.Models;

namespace Library.API.Controllers
{
    /*add PersonController*/

    [Route(RouteConstants.RouteBook)]
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        public BookController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("getAllBooks")]
        public IActionResult GetAll()
        {
            try
            {
                var result = MockData.GetAllLibraryMockData();
                var mappedResult = _mapper.Map<IEnumerable<Book>>(result) ;
                return Ok(mappedResult);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAll(int id)
        {
            try
            {
                var books = MockData.GetAllLibraryMockData();
                var booksList = books.ToList();

                var book = booksList.Where(x => x.Id == id).FirstOrDefault();
                var mappedResult = _mapper.Map<Book>(book);

                return Ok(mappedResult);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]

        public IActionResult Create([FromBody] BookModel model)
        {
            try
            {
                var books = MockData.GetAllLibraryMockData().ToList();

                var mappedModel = _mapper.Map<Book>(model);

                books.Add(mappedModel);

                return Ok(books);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
