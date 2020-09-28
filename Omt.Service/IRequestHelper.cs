using System.Net.Http;
using System.Threading.Tasks;
using Tango.Types;

namespace Omt.Service
{
    internal interface IRequestHelper
    {
        Task<Option<HttpResponseMessage>> GetAsync(string requestUri);
    }
}
