using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Krooze.EntranceTest.WriteHere.Commands;
using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestsService _testsService;

        public TestsController(ITestsService testsService)
        {
            _testsService = testsService;
        }
        
        [HttpGet("GetAllMovies")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public IActionResult GetAllMovies()
        {
            try
            {
                var response = _testsService.GetAllMovies();                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetDirector")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public IActionResult GetDirector()
        {
            try
            {
                var response = _testsService.GetDirector();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("TranslateXML")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public IActionResult TranslateXML()
        {
            try
            {
                var response = _testsService.TranslateXML();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetOtherTaxes")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public IActionResult GetOtherTaxes()
        {
            try
            {
                var cruise = _testsService.TranslateXML();
                if (cruise == null)
                    return BadRequest();

                var response = _testsService.GetOtherTaxes(cruise);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("IsThereDiscount")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public IActionResult IsThereDiscount()
        {
            try
            {
                var cruise = _testsService.TranslateXML();
                if (cruise == null)
                    return BadRequest();

                var response = _testsService.IsThereDiscount(cruise);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetInstallments/{fullPrice}")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public IActionResult GetInstallments(decimal fullPrice)
        {
            try
            {
                var response = _testsService.GetInstallments(fullPrice);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("GetCruises")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public IActionResult GetCruises([FromBody] CruiseRequestDTO cruiseRequest)
        {
            try
            {
                var response = _testsService.GetCruises(cruiseRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }    
    }
}
