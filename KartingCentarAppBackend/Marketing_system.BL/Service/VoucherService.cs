using System.Drawing;
using System.Drawing.Printing;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;
using QRCoder;

namespace Marketing_system.BL.Service
{
    public class VoucherService : IVoucherService
    {
        public IUnitOfWork _unitOfWork;
        public VoucherService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<VoucherDTO> CheckVoucher(int voucherId)
        {
            var voucherTemp = await _unitOfWork.GetVoucherRepository().GetByIdAsync(voucherId);
            if(voucherTemp != null && voucherTemp.ExpirationDate <= DateOnly.FromDateTime(DateTime.Now))
            {
                _unitOfWork.GetVoucherRepository().Delete(voucherId);
                await _unitOfWork.Save();

                var result = new VoucherDTO
                {
                    Id = voucherTemp.Id,
                    Discount = voucherTemp.Discount,
                    ExpirationDate = voucherTemp.ExpirationDate.ToString(),
                    Client_id = voucherTemp.Client_id
                };

                return result;
            }

            return null;
        }

        public async Task<bool> CreateVoucher(VoucherDTO voucher)
        {
            Random random = new Random();
            int voucherId = random.Next(1, int.MaxValue);
            PrintVoucher(voucherId, voucher.Discount);

            await _unitOfWork.GetVoucherRepository().Add(new Voucher(voucherId, DateOnly.Parse(voucher.ExpirationDate), voucher.Discount, voucher.Client_id));
            await _unitOfWork.Save();
            return true;
        }
        public async Task<bool> DeleteVoucher(int id)
        {
            _unitOfWork.GetVoucherRepository().Delete(id);
            await _unitOfWork.Save();
            return true;
        }

        public void PrintVoucher(int voucherId, int discount)
        {

            var qrcode = GenerateQRCode(voucherId);

            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += (sender, e) =>
            {
                e.Graphics.DrawImage(qrcode, 15, 40);

                Font font = new Font("Arial", 16);
                Font font1 = new Font("Arial", 18, FontStyle.Italic | FontStyle.Bold);
                Font font2 = new Font("Arial", 20, FontStyle.Bold);

                e.Graphics.DrawString("Čestitamo! Ovim kuponom ostvarujete popust na vožnju.", font2, Brushes.Black, new PointF(30, 25));
                e.Graphics.DrawString("Važi do: " + DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"), font, Brushes.Black, new PointF(qrcode.Width + 30, 80));
                e.Graphics.DrawString("Popust: " + discount.ToString() + "%", font, Brushes.Black, new PointF(qrcode.Width + 30, 110));
                e.Graphics.DrawString("Kupon je namenjen za jednokratnu upotrebu!", font1, Brushes.Black, new PointF(qrcode.Width + 30, 160));
            };

            printDocument.Print();
        }

        private Bitmap GenerateQRCode(int voucherId)
        {
            QRCodeGenerator qRCodeGenerator = new();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(voucherId.ToString(), QRCodeGenerator.ECCLevel.L);
            PngByteQRCode qrCode = new(qRCodeData);
            byte[] qrCodeBytes = qrCode.GetGraphic(6);
            using var stream = new MemoryStream(qrCodeBytes);
            return new Bitmap(stream);
        }
    }
}
