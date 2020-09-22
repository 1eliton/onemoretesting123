using System.Threading.Tasks;

namespace Omt.Application
{
    public interface IInterestApplication
    {
        Task<(bool success, double amount)> Calculate(double initialValue, double months);
    }
}