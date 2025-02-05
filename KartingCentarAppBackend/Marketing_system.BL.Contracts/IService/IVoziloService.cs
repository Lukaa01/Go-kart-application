using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IVoziloService
    {
        Task<VoziloDTO> CreateVehicle(VoziloDTO vozilo);
        Task<VoziloDTO> GetVehicleById(int id);
        Task<IEnumerable<VoziloDTO>> GetAllVehicles();
    }
}
