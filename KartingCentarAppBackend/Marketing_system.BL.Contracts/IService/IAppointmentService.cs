using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointment);
        Task<bool> DeleteAppointment(int id);
    }
}
