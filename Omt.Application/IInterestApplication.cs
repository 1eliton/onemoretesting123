using System;
using System.Threading.Tasks;
using Tango.Types;

namespace Omt.Application
{
    public interface IInterestApplication
    {
        Task<Either<Exception, double>> Calculate(double initialValue, double months);
    }
}