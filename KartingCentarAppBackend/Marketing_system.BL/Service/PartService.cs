using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;

namespace Marketing_system.BL.Service
{
    public class PartService : IPartService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public PartService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<PartDTO> CreatePart(PartDTO partDTO)
        {
            var part = await _unitOfWork.GetPartRepository().Add(new Part(partDTO.Name, partDTO.Producer, partDTO.Total));
            await _unitOfWork.Save();

            var result = new PartDTO
            {
                Id = part.Entity.Id,
                Name = part.Entity.Name,
                Producer = part.Entity.Producer,
                Total = part.Entity.Total
            };

            return result;
        }

        public async Task<PartDTO> UpdatePart(PartDTO partDTO)
        {
            var temp = _unitOfWork.GetPartRepository().Update(new Part(partDTO.Id, partDTO.Name, partDTO.Producer, partDTO.Total));
            await _unitOfWork.Save();
            if (temp != null)
            {
                return partDTO;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<PartDTO>> GetAllParts()
        {
            var tempResult = await _unitOfWork.GetPartRepository().GetAll();

            var result = tempResult.Select(part => new PartDTO
            {
                Id = part.Id,
                Name = part.Name,
                Producer = part.Producer,
                Total = part.Total,

            }).ToList();

            return result;
        }
    }
}
