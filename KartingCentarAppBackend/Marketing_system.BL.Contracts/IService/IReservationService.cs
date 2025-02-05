using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IReservationService
    {
        Task<bool> CreateReservation(ReservationDTO reservation);
        Task<bool> DeleteReservation(int id);
        Task<ReservationDTO> UpdateReservation(ReservationDTO reservation);
        Task<ReservationDTO> PayReservation(int id);
        Task<List<ReservationDTO>> GetAllReservationsForTrack(int id);
    }
}
