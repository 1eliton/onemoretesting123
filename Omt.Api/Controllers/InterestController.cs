
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Omt.Application;

namespace Omt.Api.Controllers {
    public class InterestController : ControllerBase {

        private readonly IInterestApplication _interestApplication; 
        public InterestController(IInterestApplication interestApplication)
        {
            _interestApplication = interestApplication;
        }

        /// <summary>
        /// Calcula o juros com base no valor inicial, tempo e taxa de juros.
        /// </summary>
        /// <returns>Valor com juros acrescidos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet()]
        public async Task<ActionResult> Calculate([FromQuery]double initialValue, [FromQuery]double months) 
        {
            try
            {
                var calculo = await _interestApplication.Calculate(initialValue, months);
                if (calculo.success)
                    return Ok(calculo.amount);
                
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}