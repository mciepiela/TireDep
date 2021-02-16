using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireDep.Domain.Interfaces;
using TireDep.Domain.Model;
using TireDep.Infrastructure.Repo;
using TireDep.RESTApi.Domain.Interfaces;

namespace TireDep.RESTApi.Services
{
    public class DepositService : IDepositService
    {
        //API
        private readonly IDepositRepository _depositRepository;

        public DepositService(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }
        public async Task<IEnumerable<Deposit>> ListAsync()
        {
            return await _depositRepository.ListAsync();
        }
    }
}
