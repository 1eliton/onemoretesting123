using Microsoft.Extensions.Options;
using Omt.Domain;
using System;
using System.Threading.Tasks;
using Omt.Services;
using Tango.Types;
using Tango.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace Omt.Application
{
    public class InterestApplication : IInterestApplication
    {
        private readonly AppConfig _appConfig;
        private readonly RequestHelper _requestHelper;

        public InterestApplication(IOptions<AppConfig> options, RequestHelper requestHelper)
        {
            _appConfig = options.Value;
            _requestHelper = requestHelper;
        }

        public async Task<Either<Exception, double>> Calculate(double initialValue, double months) 
        {
            try
            {
                if (!(initialValue > 0) != !(months > 0))
                    throw new Exception("dados incorretos....");

                var response = await _requestHelper
                    .Get(string.Concat(_appConfig.InterestRateUrl, _appConfig.InterestRateResource));

                if (response.ExistsRight(d => d.IsSuccessStatusCode))
                {

                    Either<bool, int> eitherValue = 10;
                    int value = eitherValue.Match(
                            methodWhenRight: number => number,
                            methodWhenLeft: boolean => 0);

                    //value = 10

                    //HttpResponseMessage x = response.Match(methodWhenRight: res => res.Content, methodWhenLeft: ex => ex);
                    
                    
                    //var rate = await response..Content.ReadAsStringAsync();
                    //var juros = Convert.ToDouble(rate);
                    //var valorFinal = Math.Pow((1 + juros), months) * initialValue;
                    //return (true, Math.Round(valorFinal, 2));
                }

                throw new Exception("Erro ao calcular juros...");

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
