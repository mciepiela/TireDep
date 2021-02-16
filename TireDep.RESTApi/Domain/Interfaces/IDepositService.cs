using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireDep.Domain.Model;

namespace TireDep.RESTApi.Domain.Interfaces
{
    public interface IDepositService
    {
        // API
        Task<IEnumerable<Deposit>> ListAsync();
    }
}
