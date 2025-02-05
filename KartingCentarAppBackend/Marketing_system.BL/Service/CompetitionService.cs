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
using Nest;

namespace Marketing_system.BL.Service
{
    public class CompetitionService : ICompetitionService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public CompetitionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCompetition(CompetitionDTO competition)
        {
            await _unitOfWork.GetCompetitionRepository().Add(new Competition(competition.Name, competition.Description, competition.DateAndTime));
            await _unitOfWork.Save();
            return true;
        }

        public async Task<List<CompetitionDTO>> GetAllFutureCompetitions()
        {
            var temp = await _unitOfWork.GetCompetitionRepository().GetAll();
            List<CompetitionDTO> result = new List<CompetitionDTO>();
            foreach (Competition c in temp)
            {
                if (c.DateAndTime >= DateTime.Now)
                {
                    var competitionDTO = new CompetitionDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        DateAndTime = c.DateAndTime,
                        Success = new List<SuccessDTO>()
                    };

                    result.Add(competitionDTO);
                }
            }

            return result;
        }

        public async Task<List<CompetitionDTO>> GetAllPastCompetitions()
        {
            var temp = await _unitOfWork.GetCompetitionRepository().GetAll();
            List<CompetitionDTO> result = new List<CompetitionDTO>();

            var tempSuccess = await _unitOfWork.GetSuccessRepository().GetAll();
            List<Success> tempSuccessResult = new List<Success>();

            var tempParticipate = await _unitOfWork.GetParticipateRepository().GetAll();
            List<Participate> tempParticipateResult = new List<Participate>();

            var tempMember = await _unitOfWork.GetMemberRepository().GetAll();
            List<Member> tempMemberResult = new List<Member>();

            DateTime today = DateTime.Now;

            foreach (var competition in temp)
            {

                if (competition.DateAndTime < today)
                {
                    var competitionDTO = new CompetitionDTO
                    {
                        Id = competition.Id,
                        Name = competition.Name,
                        Description = competition.Description,
                        DateAndTime = competition.DateAndTime,
                        Success = new List<SuccessDTO>() 
                    };

                    var relatedParticipations = tempParticipate.Where(p => p.Competition_id == competition.Id).ToList();

                    foreach (var participation in relatedParticipations)
                    {
                        var relatedSuccesses = tempSuccess.Where(s => s.Compete_id == participation.Id).ToList();

                        foreach (var success in relatedSuccesses)
                        {
                            var member = tempMember.FirstOrDefault(m => m.Id == participation.Member_id);

                            if (member != null)
                            {
                                var successDTO = new SuccessDTO
                                {
                                    Id = success.Id,
                                    Place = success.Place,
                                    Time = success.Time,
                                    Compete_id = participation.Id,
                                    MemberFirstName = member.Name,
                                    MemberLastName = member.Surname
                                };

                                competitionDTO.Success.Add(successDTO);
                            }
                        }
                    }

                    result.Add(competitionDTO);
                }
            }

            return result;

        }
    }
}
