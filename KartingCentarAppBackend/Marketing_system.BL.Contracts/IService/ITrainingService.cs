using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface ITrainingService
    {
        Task<List<TrainingDTO>> CreateTraining(int id, List<TrainingDTO> training);
        Task<bool> DeleteTraining(int id);
        Task<bool> AddMembersToTraining(int id, List<MemberDTO> members);
        Task<IEnumerable<TrainingDTO>> GetTrainingsByMemberId(int memberId);
        Task<IEnumerable<TrainingDTO>> GetAllTrainingsByTrack(int id);
        Task<List<TrainingDTO>> GetTrainingsForInstructor(int instructorId);
    }
}
