using Microsoft.AspNetCore.Mvc;
using Library.API.Constants;
using System.Linq;
using Library.Data.MockData;
using AutoMapper;
using Library.API.Models;
using System.Collections.Generic;
using Library.Data.Entities;

namespace Library.API.Controllers
{
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
                var mappedResult = _mapper.Map<IEnumerable<BookModel>>(result);

                return Ok(mappedResult);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            try
            {
                var books = MockData.GetAllLibraryMockData();
                var bookList = books.ToList();
                var book = bookList.Where(x => x.Id == id).FirstOrDefault();

                var mappedResult = _mapper.Map<BookModel>(book);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var books = MockData.GetAllLibraryMockData().ToList();
                var book = books.Where(x => x.Id == id).FirstOrDefault();

                books.Remove(book);

                return Ok(books);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] BookModel model, int id)
        {
            try
            {
                var books = MockData.GetAllLibraryMockData().ToList();
                var book = books.Where(x => x.Id == id).FirstOrDefault();
               //to be continued

                return Ok(books);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
