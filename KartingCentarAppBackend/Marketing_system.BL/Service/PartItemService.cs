using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;
using Nest;

namespace Marketing_system.BL.Service
{
    public class PartItemService : IPartItemService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public PartItemService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreatePartItem(PartItemDTO item)
        {
            await _unitOfWork.GetPartItemRepository().Add(new PartItem(item.Quantity, item.CartService_id, item.Part_id));
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> DeletePartItem(int id)
        {
            _unitOfWork.GetPartItemRepository().Delete(id);
            await _unitOfWork.Save();
            return true;
        }
    }
}
