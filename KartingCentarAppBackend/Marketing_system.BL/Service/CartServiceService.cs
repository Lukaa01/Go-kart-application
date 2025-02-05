using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;
using Nest;

namespace Marketing_system.BL.Service
{
    public class CartServiceService : ICartServiceService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public CartServiceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCartService(int servicerId, CartServiceDTO s)
        {
            var newService = await _unitOfWork.GetCartServiceRepository().Add(new CartService(s.Id, s.Date, s.Description, s.Vehicle_id));
            await _unitOfWork.Save();

            var serviser = await _unitOfWork.GetEmployeeRepository().GetByIdAsync(servicerId);
            if (newService.Entity == null || serviser == null || serviser.Type != "serviser")
            {
                return false;
            }

            serviser.Services.Add(newService.Entity);
            await _unitOfWork.Save();

            return true;
        }

        public async Task<IEnumerable<CartServiceDTO>> GetServicesByVehicleId(int id)
        {
            var temp = await _unitOfWork.GetCartServiceRepository().GetAll();
            List<CartService> tempResult = new List<CartService>();
            foreach(CartService cs in temp)
            {
                if(cs.Vehicle_id == id)
                {
                    tempResult.Add(cs);
                }
            }
            var result = tempResult.Select(service => new CartServiceDTO
            {
                Id = service.Id,
                Date = service.Date,
                Description = service.Description,
                Vehicle_id = service.Vehicle_id
            });
            return result;
        }
        public async Task<CartServiceDTO> GetService(int id)
        {
            var service = await _unitOfWork.GetCartServiceRepository().GetServiceEager(id);

            var result = new CartServiceDTO
            {
                Id = service.Id,
                Date = service.Date,
                Description = service.Description,
                Vehicle_id = service.Vehicle_id,
                PartItems = service.PartItems.Select(item => new PartItemDTO
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    CartService_id = service.Id,
                    Part = new PartDTO
                    {
                        Id = item.Part.Id,
                        Name = item.Part.Name,
                        Producer = item.Part.Producer,
                        Total = item.Part.Total
                    }

                }).ToList()
            };

            return result;
        }
    }
}
