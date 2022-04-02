using System;
using Microsoft.AspNetCore.Mvc;
using Library.API.Constants;
using AutoMapper;
using Library.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.BLL.Dto;
using Library.BLL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.API.Controllers
{
    [Route(RouteConstants.RouteBook)]
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IMapper mapper,
            IBookService bookService,
            ILogger<BookController> logger)
        {
            _mapper = mapper;
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _bookService.GetAll();
                var mappedResult = _mapper.Map<IList<BookModel>>(result);

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
                var borrower = await _bookService.Get(id);
                var mappedResult = _mapper.Map<BookModel>(borrower);

                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookModel model)
        {
            try
            {
                var mappedModel = _mapper.Map<BookDto>(model);
                var book = await _bookService.Add(mappedModel);

                return Ok(book);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] BookModel model, int id)
        {
            if (id == 0)
            {
                return BadRequest("id not provided");
            }
            try
            {
                var mappedModel = _mapper.Map<BookDto>(model);
                var isCreated = await _bookService.Edit(mappedModel);

                if (isCreated)
                {
                    return Ok("Book successfully created!");
                }
                else
                {
                    return NotFound("Book not found or not created!");
                }
               
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new ApplicationException();
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _bookService.Delete(id);
                if (book != null)
                {
                    return Ok($"Book with name ={book.Name} deleted ");
                }
                else
                {
                    return NotFound("Book not found or not deleted!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new ApplicationException();
            }
        }
    }
}
