using Microsoft.Extensions.Options;
using Omt.Domain;
using System;
using System.Threading.Tasks;
using Omt.Services;
using Tango.Types;
using Tango.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Omt.Application
{
    public class InterestApplication : IInterestApplication
    {
        private readonly AppConfig _appConfig;
        private readonly RequestHelper _requestHelper;
        private const ushort DECIMALS = 2;

        public InterestApplication(IOptions<AppConfig> options, RequestHelper requestHelper)
        {
            _appConfig = options.Value;
            _requestHelper = requestHelper;
        }

        public async Task<Option<double>> Calculate(double initialValue, double months) 
        {
            try
            {
                if (!(initialValue > 0) || !(months > 0))
                    throw new ArgumentException("O valor inicial e/ou a quantidade de mes(es) informado(s) é inválido");

                var apiResponse = await _requestHelper
                    .GetAsync(string.Concat(_appConfig.InterestRateUrl, _appConfig.InterestRateResource));

                if (apiResponse.IsSome)
                {
                    HttpResponseMessage apiResponseMessage =
                        apiResponse.Match((r) => r, () => null);

                    var responseObject =  JsonConvert.DeserializeObject<ApiResponse>
                        (await apiResponseMessage.Content.ReadAsStringAsync());
                    var finalValue = Math.Pow((1 + Convert.ToDouble(responseObject.Content)), months) * initialValue;

                    return Math.Round(finalValue, DECIMALS);

                }

                throw new Exception("Erro ao calcular juros. Tente novamente.");

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
