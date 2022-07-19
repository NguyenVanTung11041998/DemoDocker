using DockerDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("calculator/{x}/{y}")]
        public int Calculator(int x, int y)
        {
            Log.Information($"Result = {x} + {y} = {x + y}");

            return x + y;
        }

        [HttpPost]
        [Route("add")]
        public async Task AddEntityAsync(Product product)
        {
            Log.Information("Add api start");

            try
            {
                var mongoClient = new MongoClient(MongoDbConst.MongoDbConnectionString);

                var db = mongoClient.GetDatabase(MongoDbConst.DatabaseName);

                var collection = db.GetCollection<Product>(MongoDbConst.CollectionName);

                await collection.InsertOneAsync(product);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
