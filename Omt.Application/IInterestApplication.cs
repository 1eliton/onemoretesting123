using System;
using System.Threading.Tasks;
using Tango.Types;

namespace Omt.Application
{
    public interface IInterestApplication
    {
        Task<Option<double>> Calculate(double initialValue, double months);
    }
}