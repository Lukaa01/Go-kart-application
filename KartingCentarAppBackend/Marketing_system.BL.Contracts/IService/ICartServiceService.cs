using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface ICartServiceService
    {
        Task<bool> CreateCartService(int serviserId, CartServiceDTO service);
        Task<IEnumerable<CartServiceDTO>> GetServicesByVehicleId(int id);
        Task<CartServiceDTO> GetService(int id);
    }
}
