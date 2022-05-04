using DockerDemo.Entities;
using DockerDemo.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Route("api/class-room")]
    public class ClassRoomController : ControllerBase
    {
        private DemoDockerDbContext DemoDockerDbContext { get; }

        public ClassRoomController(DemoDockerDbContext dbContext)
        {
            DemoDockerDbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<ClassRoom>> GetAllAsync()
        {
            try
            {
                return await DemoDockerDbContext.ClassRooms.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);

                throw;
            }
        }
    }
}
