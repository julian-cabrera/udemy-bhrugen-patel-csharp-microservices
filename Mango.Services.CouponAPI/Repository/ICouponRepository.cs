using Mango.Services.CouponAPI.Models.DTO;

namespace Mango.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCouponByCode(string code);
    }
}
