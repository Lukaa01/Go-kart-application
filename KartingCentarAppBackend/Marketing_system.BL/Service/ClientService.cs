using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;
using Nest;

namespace Marketing_system.BL.Service
{
    public class ClientService : IClientService
    {
        public IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> BlockClient(ClientDTO client)
        {
            var temp = await _unitOfWork.GetClientRepository().GetAll();
            foreach (var item in temp)
            {
                if (item.Id == client.Id)
                {
                    item.Status = "blokiran";
                    _unitOfWork.GetClientRepository().Update(item);
                    await _unitOfWork.Save();
                    return true;
                }
            }
            return false;
        }

        public async Task<TokenDTO> CreateClient(ClientDTO client)
        {
            var userDb = await _unitOfWork.GetClientRepository().GetByEmailAsync(client.Email);
            if (userDb != null)
            {
                return null;
            }

            var result = await _unitOfWork.GetClientRepository().Add(new Client(client.Name, client.Surname, client.Email, client.Password, client.City, client.Street, client.StreetNumber, client.Phone, client.Status, client.NumberOfReservations, client.PenaltyPoints));
            await _unitOfWork.Save();

            return await _unitOfWork.GetTokenRepository().GenerateToken(result.Entity.Id, client.Email, "klijent");
        }
        public async Task<ClientDTO> GetClientById(int clientId)
        {
            var client = await _unitOfWork.GetClientRepository().GetByIdAsync(clientId);
            if (client is null)
            {
                return null;
            }

            var result = new ClientDTO 
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Password = client.Password,
                City = client.City,
                Street = client.Street,
                StreetNumber = client.StreetNumber,
                Phone = client.Phone,
                Status = client.Status,
                NumberOfReservations = client.NumberOfReservations,
                PenaltyPoints = client.PenaltyPoints
            };
            return result;
        }

        public async Task<ClientDTO> UpdateClient(ClientDTO client)
        {
            var tempResult = _unitOfWork.GetClientRepository().Update(new Client(client.Id, client.Name, client.Surname, client.Email, client.Password, client.City, client.Street, client.StreetNumber, client.Phone, client.Status, client.NumberOfReservations, client.PenaltyPoints));
            await _unitOfWork.Save();

            var result = new ClientDTO
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
                NumberOfReservations = tempResult.NumberOfReservations,
                PenaltyPoints = tempResult.PenaltyPoints
            };

            return result;
        }

        public async Task<ClientDTO> AddPenalties(ClientDTO client)
        {
            ++client.PenaltyPoints;

            var tempResult = _unitOfWork.GetClientRepository().Update(new Client(client.Id, client.Name, client.Surname, client.Email, client.Password, client.City, client.Street, client.StreetNumber, client.Phone, client.Status, client.NumberOfReservations, client.PenaltyPoints));
            await _unitOfWork.Save();

            var result = new ClientDTO
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
                NumberOfReservations = tempResult.NumberOfReservations,
                PenaltyPoints = tempResult.PenaltyPoints
            };

            return result;
        }
    }
}
