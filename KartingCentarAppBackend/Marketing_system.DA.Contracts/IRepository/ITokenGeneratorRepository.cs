using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.DA.Contracts.Model;

namespace Marketing_system.DA.Contracts.IRepository
{
    public interface ITokenGeneratorRepository
    {
        Task<TokenDTO> GenerateToken(int id, string email, string type);
    }
}
