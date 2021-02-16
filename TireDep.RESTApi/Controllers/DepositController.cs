using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TireDep.Domain.Model;
using TireDep.RESTApi.Resources;

namespace TireDep.RESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepositController : ControllerBase
    {
        private readonly Domain.Interfaces.IDepositService _depositService;
        private readonly IMapper _mapper;


        public DepositController(Domain.Interfaces.IDepositService depositService, IMapper mapper)
        {
            _depositService = depositService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DepositResource>> GetAllAsync()
        {
            var deposits = await _depositService.ListAsync();
            var resourses = _mapper.Map<IEnumerable<Deposit>, IEnumerable<DepositResource>>(deposits);
            return resourses;
        }
    }
}
