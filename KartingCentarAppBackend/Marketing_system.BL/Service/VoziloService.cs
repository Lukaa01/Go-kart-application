using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.IRepository;
using Marketing_system.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Marketing_system.BL.Service
{
    public class VoziloService : IVoziloService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public VoziloService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<VoziloDTO> CreateVehicle(VoziloDTO vozilo)
        {
            var voziloTemp = await _unitOfWork.GetVoziloRepository().Add(new Vozilo(vozilo.Id, vozilo.Marka, vozilo.Model, vozilo.Kubikaza, vozilo.Upotrebljivo, vozilo.BrojVozila));
            await _unitOfWork.Save();

            var result = new VoziloDTO
            {
                Id = voziloTemp.Entity.Id,
                Marka = voziloTemp.Entity.Marka,
                Model = voziloTemp.Entity.Model,
                Kubikaza = voziloTemp.Entity.Kubikaza,
                BrojVozila = voziloTemp.Entity.BrojVozila,
                Upotrebljivo = voziloTemp.Entity.Upotrebljivo
            };

            return result;
        }
        public async Task<IEnumerable<VoziloDTO>> GetAllVehicles()
        {
            var vehicles = await _unitOfWork.GetVoziloRepository().GetAll();
            var result = vehicles.Select(v => new VoziloDTO
            {
                Id = v.Id,
                Marka = v.Marka,
                Model = v.Model,
                Kubikaza = v.Kubikaza,
                Upotrebljivo = v.Upotrebljivo,
                BrojVozila = v.BrojVozila
            });
            return result;
        }
        public async Task<VoziloDTO> GetVehicleById(int id)
        {
            var temp = await _unitOfWork.GetVoziloRepository().GetByIdAsync(id);

            var result = new VoziloDTO
            {
                Id = temp.Id,
                Marka = temp.Marka,
                Model = temp.Model,
                Kubikaza = temp.Kubikaza,
                Upotrebljivo = temp.Upotrebljivo,
                BrojVozila = temp.BrojVozila
            };
            return result;
        }

    }
}
