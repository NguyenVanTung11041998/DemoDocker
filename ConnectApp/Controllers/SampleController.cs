using AutoMapper;
using ConnectApp.Dto;
using ConnectApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ConnectApp.Controllers
{
    [ApiController]
    [Route("api/sample")]
    public class SampleController : ControllerBase
    {
        private ConnectAppDbContext ConnectAppDbContext { get; }

        private IMapper Mapper { get; }

        public SampleController(ConnectAppDbContext connectAppDbContext, IMapper  mapper)
        {
            ConnectAppDbContext = connectAppDbContext;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<SampleADto> GetByIdAsync(Guid id)
        {
            var data = await ConnectAppDbContext.SampleAs
                            .Include(x => x.SampleBs)
                            .ThenInclude(x => x.SampleCs)
                            .ThenInclude(x => x.SampleDs)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return Mapper.Map<SampleADto>(data);
        }
    }
}
