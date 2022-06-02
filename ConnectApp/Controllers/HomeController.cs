using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConnectApp.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("calculate")]
        public async Task<int> Calculate(int x, int y)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"{ApiServerConst.ApiServerName}/home/calculator/{x}/{y}");

            if (!response.IsSuccessStatusCode) return 0;

            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(content);
        }
    }
}
