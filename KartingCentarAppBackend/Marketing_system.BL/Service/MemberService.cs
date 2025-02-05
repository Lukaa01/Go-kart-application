using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.DA.Contracts.Model;
using Marketing_system.DA.Contracts;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts.Shared;

namespace Marketing_system.BL.Service
{
    public class MemberService : IMemberService
    {
        public IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> BlockMember(MemberDTO member)
        {
            var temp = await _unitOfWork.GetMemberRepository().GetAll();
            foreach (var item in temp)
            {
                if(item.Id == member.Id)
                {
                    item.Status = "blokiran";
                    _unitOfWork.GetMemberRepository().Update(item);
                    await _unitOfWork.Save();
                    return true;
                }
            }
            return false;
        }

        public async Task<MemberDTO> CreateMember(MemberDTO member)
        {
            var tempResult = await _unitOfWork.GetMemberRepository().Add(new Member(member.Name, member.Surname, member.Email, member.Password, member.Phone, member.City, member.Street, member.StreetNumber, member.Birthday, "neaktivan", member.MemberCard, member.Category.Id, member.Instruktor_id));
            await _unitOfWork.Save();

            var result = new MemberDTO
            {
                Id = tempResult.Entity.Id,
                Name = tempResult.Entity.Name,
                Surname = tempResult.Entity.Surname,
                Email = tempResult.Entity.Email,
                Password = tempResult.Entity.Password,
                Phone = tempResult.Entity.Phone,
                City = tempResult.Entity.City,
                Street = tempResult.Entity.Street,
                StreetNumber = tempResult.Entity.StreetNumber,
                Category = tempResult.Entity.Category != null ? new CategoryDTO
                {
                    Id = tempResult.Entity.Category.Id,
                    Name = tempResult.Entity.Category.Name,
                    Price = tempResult.Entity.Category.Price
                } : null,
                Status = tempResult.Entity.Status,
                Birthday = tempResult.Entity.Birthday,
                MemberCard = tempResult.Entity.MemberCard,
                Instruktor_id = tempResult.Entity.Instruktor_id
            };

            return result;
        }
        public async Task<MemberDTO> UpdateMember(MemberDTO member)
        {
            var tempResult = _unitOfWork.GetMemberRepository().Update(new Member(member.Id, member.Name, member.Surname, member.Email, member.Password, member.Phone, member.City, member.Street, member.StreetNumber, member.Birthday, member.Status, member.MemberCard, member.Category.Id, member.Instruktor_id));
            await _unitOfWork.Save();

            var result = new MemberDTO
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
                Category = new CategoryDTO
                {
                    Id = member.Category.Id,
                    Name = member.Category.Name,
                    Price = member.Category.Price
                },
                Instruktor_id = tempResult.Instruktor_id
            };

            return result;
        }

        public async Task<MemberDTO> GetMemberById(int id)
        {
            var tempResult = await _unitOfWork.GetMemberRepository().GetMemberByIdAsync(id);

            if(tempResult is null)
            {
                return null;
            }

            var member = new MemberDTO
            {
                Id = tempResult.Id,
                Name = tempResult.Name,
                Surname = tempResult.Surname,
                Email = tempResult.Email,
                Password = tempResult.Password,
                Phone = tempResult.Phone,
                City = tempResult.City,
                Street = tempResult.City,
                StreetNumber = tempResult.StreetNumber,
                Birthday = tempResult.Birthday,
                Status = tempResult.Status,
                MemberCard = tempResult.MemberCard,
                Category = tempResult.Category != null ? new CategoryDTO
                {
                    Id = tempResult.Category.Id,
                    Name = tempResult.Category.Name,
                    Price = tempResult.Category.Price
                } : null,
                Instruktor_id = tempResult.Instruktor_id
            };

            return member;
        }

        public async Task<List<MemberDTO>> GetMembersForInstructor(int id)
        {
            var temp = await _unitOfWork.GetMemberRepository().GetMembersForInstructorEager(id);

            var members = temp.Select(tempResult => new MemberDTO
            {
                Id = tempResult.Id,
                Name = tempResult.Name,
                Surname = tempResult.Surname,
                Email = tempResult.Email,
                Password = tempResult.Password,
                Phone = tempResult.Phone,
                City = tempResult.City,
                Street = tempResult.Street,
                StreetNumber = tempResult.StreetNumber,
                Birthday = tempResult.Birthday,
                Status = tempResult.Status,
                MemberCard = tempResult.MemberCard,
                Category = tempResult.Category != null ? new CategoryDTO
                {
                    Id = tempResult.Category.Id,
                    Name = tempResult.Category.Name,
                    Price = tempResult.Category.Price
                } : null,
                Instruktor_id = tempResult.Instruktor_id
            }).ToList();

            return members;
        }

        public async Task<List<MemberDTO>> GetAllMembers()
        {
            var temp = await _unitOfWork.GetMemberRepository().GetAllMembersEager();

            var members = temp.Select(tempResult => new MemberDTO
            {
                Id = tempResult.Id,
                Name = tempResult.Name,
                Surname = tempResult.Surname,
                Email = tempResult.Email,
                Password = tempResult.Password,
                Phone = tempResult.Phone,
                City = tempResult.City,
                Street = tempResult.Street,
                StreetNumber = tempResult.StreetNumber,
                Birthday = tempResult.Birthday,
                Status = tempResult.Status,
                MemberCard = tempResult.MemberCard,
                Category = tempResult.Category != null ? new CategoryDTO
                {
                    Id = tempResult.Category.Id,
                    Name = tempResult.Category.Name,
                    Price = tempResult.Category.Price
                } : null,
                Instruktor_id = tempResult.Instruktor_id
            }).ToList();

            return members;
        }
    }
}
