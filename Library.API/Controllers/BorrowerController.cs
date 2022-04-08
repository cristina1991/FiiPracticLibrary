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
        public async Task<IActionResult> Create([FromBody] BorrowerModel model)
        {
            try
            {
                var mappedModel = _mapper.Map<BorrowerDto>(model);
                var borrower = await _borrowerService.Add(mappedModel);

                return Ok(borrower);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }



        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] BorrowerModel model, int id)
        {
            if (id == 0)
            {
                return BadRequest("id not provided");
            }

            try
            {
                var mappedModel = _mapper.Map<BorrowerDto>(model);
                var isCreated = await _borrowerService.Edit(mappedModel);

                if (isCreated)
                {
                    return Ok("Borrower succesfully created!");
                }
                else
                {
                    return NotFound("Borrower not found or not created!");
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
                var borrower = await _borrowerService.Delete(id);
                if (borrower != null)
                {
                    return Ok($"Borrower with name ={borrower.FirstName} {borrower.LastName} deleted ");
                }
                else
                {
                    return NotFound("Borrower not found or not deleted!");
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
