using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IVoucherService
    {
        Task<bool> CreateVoucher(VoucherDTO voucher);
        Task<bool> DeleteVoucher(int id);
        Task<VoucherDTO> CheckVoucher(int voucherId);
        void PrintVoucher(int voucherId, int discount);
    }
}
