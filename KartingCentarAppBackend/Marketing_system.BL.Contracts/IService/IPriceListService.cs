using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IPriceListService
    {
        Task<bool> CreatePriceListItem(PriceListItemDTO item);
        Task<bool> UpdatePriceListItem(PriceListItemDTO item);
        Task<List<PriceListItemDTO>> GetAllItems();
    }
}
