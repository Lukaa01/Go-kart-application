﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IPartItemService
    {
        Task<bool> CreatePartItem(PartItemDTO item);
        Task<bool> DeletePartItem(int id);
    }
}
