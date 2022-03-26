using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.Constants;
using Library.API.Models;
using Library.BLL.Interfaces;
using Library.Data.Entities;
using Library.Data.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.API.Controllers
{
    [Route(RouteConstants.RouteBorrower)]
    public class BorrowerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBorrowerService _borrowerService;
        private readonly ILogger<BorrowerController> _logger;

        public BorrowerController(
            IMapper mapper, 
            IBorrowerService borrowerService,
            ILogger<BorrowerController> logger)
        {
            _mapper = mapper;
            _borrowerService = borrowerService;
            _logger = logger;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _borrowerService.GetAll();
                var mappedResult = _mapper.Map<IList<BorrowerModel>>(result);

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
                var borrower = await _borrowerService.Get(id);
                var mappedResult = _mapper.Map<BorrowerModel>(borrower);

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
