using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;

namespace Marketing_system.BL.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        public IUnitOfWork _unitOfWork {  get; set; }
        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TokenDTO> Login(string email, string password)
        {
            var member = await _unitOfWork.GetMemberRepository().GetByEmailAsync(email);
            if (member != null)
            {
                if(member.Password == password && member.Status != "blokiran" || member.Status != "neaktivan")
                {
                    return await _unitOfWork.GetTokenRepository().GenerateToken(member.Id, email, "clan");
                }
            }
            var client = await _unitOfWork.GetClientRepository().GetByEmailAsync(email);
            if (client != null)
            {
                if(client.Password == password && client.Status != "blokiran" || client.Status != "neaktivan")
                {
                    return await _unitOfWork.GetTokenRepository().GenerateToken(client.Id, email, "klijent");
                }
            }
            var employee = await _unitOfWork.GetEmployeeRepository().GetByEmailAsync(email);
            if (employee != null)
            {
                if(employee.Password == password && employee.Status != "blokiran" || employee.Status != "neaktivan")
                {
                    return await _unitOfWork.GetTokenRepository().GenerateToken(employee.Id, email, employee.Type);
                }
            }
            return null;
        }
    }
}
