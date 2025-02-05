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
    public class PriceListItemService : IPriceListService
    {
        public IUnitOfWork _unitOfWork;
        public PriceListItemService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreatePriceListItem(PriceListItemDTO item)
        {
            await _unitOfWork.GetPriceListItemRepository().Add(new PriceListItem(item.Name, item.Amount));
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> UpdatePriceListItem(PriceListItemDTO item)
        {
            _unitOfWork.GetPriceListItemRepository().Update(new PriceListItem(item.Id, item.Name, item.Amount));
            await _unitOfWork.Save();
            return true;
        }
        public async Task<List<PriceListItemDTO>> GetAllItems()
        {
            var itemsTemp = await _unitOfWork.GetPriceListItemRepository().GetAll();

            var items = itemsTemp.Select(item => new PriceListItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Amount = item.Amount
            }).ToList();

            return items;
        }
    }
}
