using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.DA.Contracts.Model;

namespace Marketing_system.DA.Contracts.IRepository
{
    public interface ITrainingRepository : IRepository<Training>
    {
        Task<IEnumerable<Training>> GetAllTrainings();

        Task<bool> DeleteOrganizuje(int id);
    }
}
