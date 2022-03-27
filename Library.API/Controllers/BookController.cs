using Microsoft.AspNetCore.Mvc;
using Library.API.Constants;
using System.Linq;
using Library.Data.MockData;
using AutoMapper;
using Library.API.Models;
using System.Collections.Generic;
using Library.Data.Entities;
using Library.BLL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace Library.API.Controllers
{
    [Route(RouteConstants.RouteBook)]
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly ILogger<BorrowerController> _logger;

        public BookController(
            IMapper mapper,
            IBookService bookService,
            ILogger<BorrowerController> logger)
        {
            _mapper = mapper;
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet("getAllBooks")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _bookService.GetAll();
                var mappedResult = _mapper.Map<IEnumerable<BookModel>>(result);

                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var books = await _bookService.Get(id);
                var mappedResult = _mapper.Map<IEnumerable<BookModel>>(books);
                
                //var bookList = books.ToList();
                //var book = bookList.Where(x => x.Id == id).FirstOrDefault();
                //var mappedResult = _mapper.Map<BookModel>(book);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
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
