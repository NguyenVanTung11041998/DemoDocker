using DockerDemo.Entities;
using DockerDemo.Helpers;
using DockerDemo.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using Serilog;
using System;
using System.Threading.Tasks;
using Product = DockerDemo.Entities.Product;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : Controller
    {
        private ITemplateAppService TemplateAppService { get; }

        public HomeController(ITemplateAppService templateAppService)
        {
            TemplateAppService = templateAppService;
        }

        [HttpPost]
        [Route("export-pdf")]
        public async Task<FileStreamResult> DownloadFileAsync(Student student)
        {
            var html = await TemplateAppService.RenderAsync("Index", student);

            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = PuppeteerExtensions.ExecutablePath
            });

            await using var page = await browser.NewPageAsync();

            await page.EmulateMediaTypeAsync(MediaType.Screen);

            await page.SetContentAsync(html);

            var pdfContent = await page.PdfStreamAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true
            });

            return File(pdfContent, "application/pdf", "file.pdf");
        }

        [HttpGet]
        [Route("calculator/{x}/{y}")]
        public int Calculator(int x, int y)
        {
            Log.Information($"Result = {x} + {y} = {x + y}");

            return x + y;
        }

        [HttpGet]
        [Route("test/{x}")]
        public string Test(string x)
        {
            return $"Hello {x}";
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
