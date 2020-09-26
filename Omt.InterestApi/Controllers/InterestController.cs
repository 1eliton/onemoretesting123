using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Omt.InterestApi.Controllers
{
    /// <summary>
    /// Api cuja responsabilidade é devolver a taxa de juros
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class InterestController : ControllerBase
    {
        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet, Route("taxajuros")]
        public async Task<ActionResult> GetInterestRate() 
            => Ok(0.01);
    }
}
