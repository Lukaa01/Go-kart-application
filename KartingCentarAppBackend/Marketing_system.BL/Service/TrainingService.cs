using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nest;

namespace Marketing_system.BL.Service
{
    public class TrainingService : ITrainingService
    {
        public IUnitOfWork _unitOfWork;
        public TrainingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TrainingDTO>> CreateTraining(int id, List<TrainingDTO> trainings)
        {
            var instruktor = await _unitOfWork.GetEmployeeRepository().GetByIdAsync(id);
            List<Training> trainingsList = new();

            foreach (TrainingDTO training in trainings)
            {
                var result = await _unitOfWork.GetAppointmentRepository().Add(new Appointment(training.Appointment.StartTime, training.Appointment.EndTime, training.Appointment.Track_id));
                await _unitOfWork.Save();

                var newTraining = await _unitOfWork.GetTrainingRepository().Add(new Training(training.Type, result.Entity.Id));
                await _unitOfWork.Save();

                if (newTraining.Entity == null || instruktor == null || instruktor.Type != "instruktor")
                {
                    return null;
                }
                instruktor.Trainings.Add(newTraining.Entity);
                await _unitOfWork.Save();

                trainingsList.Add(newTraining.Entity);
            }


            var resultList = trainingsList.Select(training => new TrainingDTO
            {
                Id = training.Id,
                Type = training.Type,
                Appointment = training.Appointment != null ? new AppointmentDTO
                {
                    Id = training.Appointment.Id,
                    StartTime = training.Appointment.StartTime,
                    EndTime = training.Appointment.EndTime,
                    Track_id = training.Appointment.Track_id
                } : null
            }).ToList();

            return resultList;
        }
        public async Task<bool> AddMembersToTraining(int trainingId, List<MemberDTO> members)
        {
            List<Member> membersTemp = members.Select(tempResult => new Member
            {
                Id = tempResult.Id,
                Name = tempResult.Name,
                Surname = tempResult.Surname,
                Email = tempResult.Email,
                Password = tempResult.Password,
                City = tempResult.City,
                Street = tempResult.Street,
                StreetNumber = tempResult.StreetNumber,
                Phone = tempResult.Phone,
                Status = tempResult.Status,
                Birthday = tempResult.Birthday,
                MemberCard = tempResult.MemberCard,
                Category_id = tempResult.Category.Id,
                Instruktor_id = tempResult.Instruktor_id
            }).ToList();

            var training = await _unitOfWork.GetTrainingRepository().GetByIdAsync(trainingId);
            if (training == null)
            {
                return false;
            }

            foreach(Member m in membersTemp)
            {
                training.Members.Add(m);
            }

            await _unitOfWork.Save();
            return true;

        }
        public async Task<IEnumerable<TrainingDTO>> GetTrainingsByMemberId(int memberId)
        {
            var member = await _unitOfWork.GetMemberRepository().GetMemberWithTrainingsEager(memberId);
            if(member is null)
            {
                return null;
            }
            var trainings = member.Trainings.Select(training => new TrainingDTO
            {
                Id = training.Id,
                Type = training.Type,
                Appointment = training.Appointment != null ? new AppointmentDTO
                {
                    Id = training.Appointment.Id,
                    StartTime = training.Appointment.StartTime,
                    EndTime = training.Appointment.EndTime,
                    Track_id = training.Appointment.Track_id
                } : null
            });

            return trainings;
        }

        public async Task<List<TrainingDTO>> GetTrainingsForInstructor(int instructorId)
        {
            var employee = await _unitOfWork.GetEmployeeRepository().GetTrainingsForInstructorEager(instructorId);
            if (employee is null)
            {
                return null;
            }
            var trainings = employee.Trainings.Select(training => new TrainingDTO
            {
                Id = training.Id,
                Type = training.Type,
                Appointment = training.Appointment != null ? new AppointmentDTO
                {
                    Id = training.Appointment.Id,
                    StartTime = training.Appointment.StartTime,
                    EndTime = training.Appointment.EndTime,
                    Track_id = training.Appointment.Track_id
                } : null
            }).ToList();

            return trainings;
        }
        public async Task<IEnumerable<TrainingDTO>> GetAllTrainingsByTrack(int id)
        {
            var trainingsTemp = await _unitOfWork.GetTrainingRepository().GetAllTrainings();
            List<TrainingDTO> list = new();

            if (trainingsTemp is null)
            {
                return null;
            }
            var trainings = trainingsTemp.Select(training => new TrainingDTO
            {
                Id = training.Id,
                Type = training.Type,
                Appointment = training.Appointment != null ? new AppointmentDTO
                {
                    Id = training.Appointment.Id,
                    StartTime = training.Appointment.StartTime,
                    EndTime = training.Appointment.EndTime,
                    Track_id = training.Appointment.Track_id
                } : null
            });

            foreach(var training in trainings)
            {
                if (training.Appointment != null && training.Appointment.Track_id == id)
                {
                    list.Add(training);
                }
            }

            return list;
        }

        public async Task<bool> DeleteTraining(int id)
        {
            await _unitOfWork.GetTrainingRepository().DeleteOrganizuje(id);
            await _unitOfWork.Save();

            _unitOfWork.GetTrainingRepository().Delete(id);
            await _unitOfWork.Save();

            return true;
        }
    }
}
