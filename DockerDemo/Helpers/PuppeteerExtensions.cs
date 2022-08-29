using Microsoft.AspNetCore.Hosting;
using PuppeteerSharp;
using System.IO;
using System.Threading.Tasks;

namespace DockerDemo.Helpers
{
    public static class PuppeteerExtensions
    {
        private static string executablePath;

        public static async Task PreparePuppeteerAsync(this IWebHostEnvironment hostingEnvironment)
        {
            var downloadPath = Path.Join(hostingEnvironment.ContentRootPath, @"\puppeteer");

            var browserOptions = new BrowserFetcherOptions { Path = downloadPath };

            var browserFetcher = new BrowserFetcher(browserOptions);

            executablePath = browserFetcher.GetExecutablePath(BrowserFetcher.DefaultChromiumRevision);

            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
        }

        public static string ExecutablePath => executablePath;
    }
}
