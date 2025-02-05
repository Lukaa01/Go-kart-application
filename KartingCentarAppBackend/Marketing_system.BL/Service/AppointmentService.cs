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
    public class AppointmentService : IAppointmentService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public AppointmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointment)
        {
            var appointmentTemp = await _unitOfWork.GetAppointmentRepository().Add(new Appointment(appointment.StartTime, appointment.EndTime, appointment.Track_id));
            await _unitOfWork.Save();

            var result = new AppointmentDTO
            {
                Id = appointmentTemp.Entity.Id,
                StartTime = appointmentTemp.Entity.StartTime,
                EndTime = appointmentTemp.Entity.EndTime,
                Track_id = appointmentTemp.Entity.Track_id
            };

            return result;
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            _unitOfWork.GetAppointmentRepository().Delete(id);
            await _unitOfWork.Save();
            return true;
        }
    }
}
