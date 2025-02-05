using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Marketing_system.BL.Service
{
    public class PartRequestService : IPartRequestService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public PartRequestService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<PartRequestDTO> CreatePartRequest(PartRequestDTO request)
        {
            var req = await _unitOfWork.GetPartRequestRepository().Add(new PartRequest(request.Quantity, request.Name, request.Producer, request.Part.Id, DateOnly.Parse(request.Date), request.Status));
            await _unitOfWork.Save();

            var result = new PartRequestDTO
            {
                Id = req.Entity.Id,
                Quantity = req.Entity.Quantity,
                Name = req.Entity.Name,
                Producer = req.Entity.Producer,
                Date = req.Entity.Date.ToString(),
                Status = req.Entity.Status,
                Part =  new PartDTO
                {
                    Id = request.Part.Id,
                    Name = request.Part.Name,
                    Producer = request.Part.Producer,
                    Total = request.Part.Total
                }
            };

            return result;
        }
        public async Task<List<PartRequestDTO>> GetAllPartRequests()
        {
            var reqTemp = await _unitOfWork.GetPartRequestRepository().GetAllEager();
            List<PartRequest> temp = new List<PartRequest>();

            Console.WriteLine(reqTemp);

            foreach (var part in reqTemp)
            {
                if(part.Status == "prihvacen")
                {
                    temp.Add(part);
                }
            }

            foreach (var part in reqTemp)
            {
                if (part.Status == "podnet")
                {
                    temp.Add(part);
                }
            }

            foreach (var part in reqTemp)
            {
                if (part.Status == "odbijen")
                {
                    temp.Add(part);
                }
            }

            foreach (var part in reqTemp)
            {
                if (part.Status == "stiglo")
                {
                    temp.Add(part);
                }
            }

            var result = temp.Select(req => new PartRequestDTO
            {
                Id = req.Id,
                Quantity = req.Quantity,
                Name = req.Name,
                Producer = req.Producer,
                Date = req.Date.ToString(),
                Status = req.Status,
                Part = req.Part != null ? new PartDTO
                {
                    Id = req.Part.Id,
                    Name = req.Part.Name,
                    Producer = req.Part.Producer,
                    Total = req.Part.Total
                } : null
            }).ToList();

            return result;
        }

        public async Task<List<PartRequestDTO>> GetAllPartRequestsForAdmin()
        {
            var reqTemp = await _unitOfWork.GetPartRequestRepository().GetAllEager();
            List<PartRequest> temp = new List<PartRequest>();

            foreach (var part in reqTemp)
            {
                if (part.Status == "podnet")
                {
                    temp.Add(part);
                }
            }

            var result = temp.Select(req => new PartRequestDTO
            {
                Id = req.Id,
                Quantity = req.Quantity,
                Name = req.Name,
                Producer = req.Producer,
                Date = req.Date.ToString(),
                Status = req.Status,
                Part = req.Part != null ? new PartDTO
                {
                    Id = req.Part.Id,
                    Name = req.Part.Name,
                    Producer = req.Part.Producer,
                    Total = req.Part.Total
                } : null
            }).ToList();

            return result;
        }

        public async Task<PartRequestDTO> UpdatePartRequest(PartRequestDTO request)
        {
            var temp = _unitOfWork.GetPartRequestRepository().Update(new PartRequest(request.Id, request.Quantity, request.Name, request.Producer, request.Part.Id, DateOnly.Parse(request.Date), request.Status));
            await _unitOfWork.Save();
            if (temp != null)
            {
                return request;
            }
            else
            {
                return null;
            }
        }
    }
}
