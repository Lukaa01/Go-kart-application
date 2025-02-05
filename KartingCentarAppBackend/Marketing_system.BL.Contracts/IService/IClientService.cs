using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;

namespace Marketing_system.BL.Contracts.IService
{
    public interface IClientService
    {
        Task<TokenDTO> CreateClient(ClientDTO client);
        Task<bool> BlockClient(ClientDTO client);
        Task<ClientDTO> GetClientById(int clientId);
        Task<ClientDTO> UpdateClient(ClientDTO client);
        Task<ClientDTO> AddPenalties(ClientDTO client);
    }
}
