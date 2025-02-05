using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface ICompetitionService
    {
        Task<bool> CreateCompetition(CompetitionDTO competition);
        Task<List<CompetitionDTO>> GetAllFutureCompetitions();
        Task<List<CompetitionDTO>> GetAllPastCompetitions();
    }
}
