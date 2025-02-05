using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IPartService
    {
        Task<PartDTO> CreatePart(PartDTO partDTO);
        Task<PartDTO> UpdatePart(PartDTO partDTO);
        Task<List<PartDTO>> GetAllParts();
    }
}
