using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IPartRequestService
    {
        Task<PartRequestDTO> CreatePartRequest(PartRequestDTO request);
        Task<PartRequestDTO> UpdatePartRequest(PartRequestDTO request);
        Task<List<PartRequestDTO>> GetAllPartRequests();
        Task<List<PartRequestDTO>> GetAllPartRequestsForAdmin();
    }
}
