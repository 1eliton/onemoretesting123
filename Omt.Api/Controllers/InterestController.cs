
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Omt.Application;
using Microsoft.Extensions.Configuration;
using Omt.Domain;
using Microsoft.Extensions.Options;
using Tango.Types;
using System.Reflection;

namespace Omt.Api.Controllers {
    /// <summary>
    /// Controller responsável por tratar as requisições de cálculo de juros
    /// </summary>
    [ApiController, Route("[controller]")]
    public class InterestController : ControllerBase {

        private readonly IInterestApplication _interestApplication;
        private const string SHOW_ME_THE_CODE = "https://github.com/1eliton/onemoretesting123";


        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="interestApplication"></param>
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
        [HttpGet, Route("calculajuros")]
        public async Task<ActionResult<ApiResponse>> Calculate([FromQuery]double initialValue, double months) 
        {
            var apiResponse = new ApiResponse();
            try
            {
                var calculo = await _interestApplication.Calculate(initialValue, months);

                // Instâncias de Option<T> encapsulam um valor que pode ou não existir. Este valor só pode ser acessado através do método Match. 
                // Ver mais ref. este pacote em: https://gabriel-schade-cardoso.gitbook.io/tango-br/tipos/introduction-1
                if (calculo.IsSome)
                {
                    double amount = calculo
                        .Match((a) => amount = a, () => 0);
                    return Ok(apiResponse.AddSuccess(amount));
                }

                return BadRequest(apiResponse.AddFailure("Erro ao calcular os juros. Por favor, tente novamente."));
            }
            catch (Exception e)
            {
                return BadRequest(apiResponse.AddFailure(e.Message, e));
            }
        }

        /// <summary>
        /// Url do projeto no github
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("showmethecode"), ProducesResponseType(200)]
        public async Task<IActionResult> ShowMeTheCode()
            => Ok(SHOW_ME_THE_CODE);
    }
}