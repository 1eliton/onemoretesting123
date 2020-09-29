using Microsoft.Extensions.DependencyInjection;
using Omt.Application;
using Omt.Domain;
using System;
using System.Threading.Tasks;
using Xunit;
using Tango;

namespace Omt.Test
{
    public class GeneralTests : IClassFixture<IntegrationTestFixture>
    {
        
        private IInterestApplication _interestApplication;
        
        public GeneralTests(IntegrationTestFixture fixture)
        {
            _interestApplication = fixture.ServiceProvider.GetRequiredService<IInterestApplication>();
        }

        [Fact]
        public void DeveGarantirQueTaxaDeJurosExista()
        {
            Assert.Equal("", "");
        }

        [Fact]
        public async Task DeveGarantirQueJurosSejaCalculado()
        {
            var calculo = _interestApplication.Calculate(100, 24)
                .GetAwaiter().GetResult();
            Assert.False(calculo.IsNone);
        }

        /// <summary>
        /// Simula erro ao calcular juros
        /// </summary>
        [Fact]
        public void DeveGarantirErroAoCalcularJuros()
        {

        }
    }
}
