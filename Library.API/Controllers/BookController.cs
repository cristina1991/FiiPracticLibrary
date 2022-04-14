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
        private readonly IBookValidations _bookValidations;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IMapper mapper,
            IBookService bookService,
            IBookValidations bookValidations,
            ILogger<BookController> logger)
        {
            _mapper = mapper;
            _bookService = bookService;
            _bookValidations = bookValidations;
            _logger = logger;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _bookService.GetAll();
                if (result == null)
                {
                    return Ok("No books found!");
                }
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
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest("id not provided");
            }
            try
            {
                var book = await _bookService.Get(id);
                if (book == null)
                {
                    return Ok("Book not found!");
                }
                var mappedResult = _mapper.Map<BookModel>(book);

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
            if (model == null)
            {
                return BadRequest("The data entered is incorrect!");
            }
            try
            {
                var isBorrowerIdValid = await _bookValidations.IsBorrowerIdValid(model.BorrowerId);
                if (!isBorrowerIdValid)
                {
                    return BadRequest("BorrowerId entered is invalid!");
                }
                var mappedModel = _mapper.Map<BookDto>(model);
                var result = await _bookService.Add(mappedModel);
                
                if (result != null)
                {
                    return Ok(result);
                    //return Ok("The book has been successfully added!");
                }
                else
                {
                    return BadRequest("Strange error occurred! Please try again later!");
                }
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
            if (model == null)
            {
                return BadRequest("The data entered is incorrect!");
            }
            try
            {
                model.Id = id;

                var isBorrowerIdValid = await _bookValidations.IsBorrowerIdValid(model.BorrowerId);
                if (!isBorrowerIdValid)
                {
                    return BadRequest("BorrowerId entered is invalid!");
                }

                var existsBookWithId = await _bookValidations.ExistsBookById(model.Id);
                if (!existsBookWithId)
                {
                    return BadRequest("Book not found!");
                }
                var mappedModel = _mapper.Map<BookDto>(model);
                var response = await _bookService.Edit(mappedModel);

                if (response)
                {
                    return Ok("The book has been successfully edited!");
                }
                else
                {
                    return BadRequest("Strange error occurred! Please try again later!");
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
            if (id == 0)
            {
                return BadRequest("id not provided");
            }
            try
            {
                var book = await _bookService.Delete(id);
                if (book != null)
                {
                    return Ok($"Book with name {book.Name} was deleted ");
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
