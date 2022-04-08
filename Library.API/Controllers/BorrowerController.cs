using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.Constants;
using Library.API.Models;
using Library.BLL.Dto;
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
                if (result == null)
                {
                    return Ok("No borrowers were found!");
                }
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
            if (id == 0)
            {
                return BadRequest("id not provided");
            }
            try
            {
                var borrower = await _borrowerService.Get(id);
                if (borrower == null)
                {
                    return Ok("Borrower not found!");
                }
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
        public async Task<IActionResult> Create([FromBody] BorrowerModel model)
        {
            if (model == null)
            {
                return BadRequest("The data entered is incorrect!");
            }
            try
            {
                var mappedModel = _mapper.Map<BorrowerDto>(model);
                var result = await _borrowerService.Add(mappedModel);

                if (result == "Success")
                {
                    return Ok("Borrower successfully edited!");
                }
                else if (result == "Error1")
                {
                    return BadRequest("The books entered do not correspond to the database!");
                }
                else if (result == "Error2")
                {
                    return BadRequest("An introduced book has already been borrowed!");
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("id not provided");
            }
            try
            {
                var borrower = await _borrowerService.Delete(id);
                if (borrower != null)
                {
                    return Ok($"Borrower with name {borrower.FirstName} {borrower.LastName} deleted ");
                }
                else
                {
                    return NotFound("Book not found or not deleted!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] BorrowerModel model, int id)
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
                var mappedModel = _mapper.Map<BorrowerDto>(model);
                var result = await _borrowerService.Edit(mappedModel);

                if (result=="Success")
                {
                    return Ok("Borrower successfully edited!");
                }
                else if (result == "Error1")
                {
                    return BadRequest("Borrower not found or not created!");
                }
                else if (result == "Error2")
                {
                    return BadRequest("The books entered do not correspond to the database!");
                }
                else if (result == "Error3")
                {
                    return BadRequest("An introduced book has already been borrowed!");
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
                //throw new ApplicationException();
            }
        }
    }
}
