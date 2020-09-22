using System;
using System.Threading.Tasks;

namespace Omt.Application
{
    public class InterestApplication : IInterestApplication
    {
        public InterestApplication()
        {
            
        }
        
        public async Task<(bool success, double amount)> Calculate(double initialValue, double months) 
        {
            // validar os parametros recebidos com fluentvalidation...
            double interestRate = 0; // busca taxa de juros na outra api

            var juros = Convert.ToDouble(interestRate);
            var valorFinal = Math.Pow((1 + juros), months) * initialValue;
            return (true, Math.Round(valorFinal, 2));
        }
    }
}
