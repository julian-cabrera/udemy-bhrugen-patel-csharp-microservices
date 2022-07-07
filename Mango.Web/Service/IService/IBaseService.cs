using Mango.Web.Models;
using Mango.Web.Models.DTO;

namespace Mango.Web.Service.IService
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
