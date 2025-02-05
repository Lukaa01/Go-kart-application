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
    public class ReservationService : IReservationService
    {
        public IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateReservation(ReservationDTO reservation)
        {
            reservation.Appointment.StartTime.AddHours(2);
            reservation.Appointment.EndTime.AddHours(2);
            var appointment = await _unitOfWork.GetAppointmentRepository().Add(new Appointment(reservation.Appointment.StartTime, reservation.Appointment.EndTime, reservation.Appointment.Track_id));
            await _unitOfWork.Save();

            await _unitOfWork.GetReservationRepository().Add(new Reservation(reservation.NumberOfPeople, 2, appointment.Entity.Id, reservation.Name, reservation.Surname, reservation.Phone, reservation.IsPaid));
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> DeleteReservation(int id)
        {
            _unitOfWork.GetReservationRepository().Delete(id);
            await _unitOfWork.Save();
            return true;
        }
   
        public async Task<ReservationDTO> UpdateReservation(ReservationDTO reservation)
        {
            var reservationTemp = _unitOfWork.GetReservationRepository().Update(new Reservation(reservation.Id, reservation.Client.Id, reservation.Appointment.Id, reservation.Name, reservation.Surname, reservation.Phone, reservation.IsPaid));
            await _unitOfWork.Save();
            var result = new ReservationDTO
            {
                Id = reservationTemp.Id,
                NumberOfPeople = reservationTemp.NumberOfPeople,
                Client = new ClientDTO
                {
                    Id = reservationTemp.Client.Id,
                    Name = reservationTemp.Client.Name,
                    Surname = reservationTemp.Client.Surname,
                    Email = reservationTemp.Client.Email,
                    Password = reservationTemp.Client.Password,
                    City = reservationTemp.Client.City,
                    Street = reservationTemp.Client.Street,
                    StreetNumber = reservationTemp.Client.StreetNumber,
                    Phone = reservationTemp.Client.Phone,
                    Status = reservationTemp.Client.Status,
                    NumberOfReservations = reservationTemp.Client.NumberOfReservations,
                    PenaltyPoints = reservationTemp.Client.PenaltyPoints
                },
                Name = reservationTemp.Name,
                Surname = reservationTemp.Surname,
                Phone = reservationTemp.Phone,
                IsPaid = reservationTemp.IsPaid,
                Appointment = new AppointmentDTO
                {
                    Id = reservationTemp.Appointment.Id,
                    StartTime = reservationTemp.Appointment.StartTime,
                    EndTime = reservationTemp.Appointment.EndTime,
                    Track_id =reservationTemp.Appointment.Track_id,
                },
            };

            return result;
        }

        public async Task<ReservationDTO> PayReservation(int id)
        {
            var res = await _unitOfWork.GetReservationRepository().GetReservationByIdAsync(id);
            res.IsPaid = true;
            var reservationTemp = _unitOfWork.GetReservationRepository().Update(res);
            await _unitOfWork.Save();

            var result = new ReservationDTO
            {
                Id = reservationTemp.Id,
                NumberOfPeople = reservationTemp.NumberOfPeople,
                Client = reservationTemp.Client != null ? new ClientDTO
                {
                    Id = reservationTemp.Client.Id,
                    Name = reservationTemp.Client.Name,
                    Surname = reservationTemp.Client.Surname,
                    Email = reservationTemp.Client.Email,
                    Password = reservationTemp.Client.Password,
                    City = reservationTemp.Client.City,
                    Street = reservationTemp.Client.Street,
                    StreetNumber = reservationTemp.Client.StreetNumber,
                    Phone = reservationTemp.Client.Phone,
                    Status = reservationTemp.Client.Status,
                    NumberOfReservations = reservationTemp.Client.NumberOfReservations,
                    PenaltyPoints = reservationTemp.Client.PenaltyPoints
                } : null,
                Name = reservationTemp.Name,
                Surname = reservationTemp.Surname,
                Phone = reservationTemp.Phone,
                IsPaid = reservationTemp.IsPaid,
                Appointment = new AppointmentDTO
                {
                    Id = reservationTemp.Appointment.Id,
                    StartTime = reservationTemp.Appointment.StartTime,
                    EndTime = reservationTemp.Appointment.EndTime,
                    Track_id = reservationTemp.Appointment.Track_id,
                },
            };

            return result;
        }

        public async Task<List<ReservationDTO>> GetAllReservationsForTrack(int id)
        {
            var reservationsTemp = await _unitOfWork.GetReservationRepository().GetAllReservationsEager();
            List<ReservationDTO> list = new();
            if (reservationsTemp is null)
            {
                return null;
            }
            var reservations = reservationsTemp.Select(reservation => new ReservationDTO
            {
                Id = reservation.Id,
                NumberOfPeople = reservation.NumberOfPeople,
                Name = reservation.Name,
                Surname = reservation.Surname,
                Phone = reservation.Phone,
                IsPaid = reservation.IsPaid,
                Client = new ClientDTO
                {
                    Id = reservation.Client.Id,
                    Name = reservation.Client.Name,
                    Surname = reservation.Client.Surname,
                    Email = reservation.Client.Email,
                    Password = reservation.Client.Password,
                    City = reservation.Client.City,
                    Street = reservation.Client.Street,
                    StreetNumber = reservation.Client.StreetNumber,
                    Phone = reservation.Client.Phone,
                    Status = reservation.Client.Status,
                    NumberOfReservations = reservation.Client.NumberOfReservations,
                    PenaltyPoints = reservation.Client.PenaltyPoints
                },
                Appointment = reservation.Appointment != null ? new AppointmentDTO
                {
                    Id = reservation.Appointment.Id,
                    StartTime = reservation.Appointment.StartTime,
                    EndTime = reservation.Appointment.EndTime,
                    Track_id = reservation.Appointment.Track_id
                } : null
            }).ToList();

            foreach(var reservation in reservations)
            {
                if (reservation.Appointment != null && reservation.Appointment.Track_id == id)
                {
                    list.Add(reservation);
                }
            }

            return list;
        }
    }
}
