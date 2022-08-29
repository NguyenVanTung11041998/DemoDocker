using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DockerDemo.Services
{
    public class RazorViewsTemplateAppService : ITemplateAppService
    {
        private IRazorViewEngine ViewEngine { get; }
        private IServiceProvider ServiceProvider { get; }
        private ITempDataProvider TempDataProvider { get; }
        private ILogger<RazorViewsTemplateAppService> Logger { get; }

        public RazorViewsTemplateAppService(
            IRazorViewEngine viewEngine,
            IServiceProvider serviceProvider,
            ITempDataProvider tempDataProvider,
            ILogger<RazorViewsTemplateAppService> logger
        )
        {
            ViewEngine = viewEngine;
            ServiceProvider = serviceProvider;
            TempDataProvider = tempDataProvider;
            Logger = logger;
        }

        public async Task<string> RenderAsync<TViewModel>(string templateFileName, TViewModel viewModel)
        {
            var httpContext = new DefaultHttpContext
            {
                RequestServices = ServiceProvider
            };

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            await using var outputWriter = new StringWriter();

            var viewResult = ViewEngine.FindView(actionContext, templateFileName, false);

            var viewDictionary = new ViewDataDictionary<TViewModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = viewModel
            };

            var tempDataDictionary = new TempDataDictionary(httpContext, TempDataProvider);

            if (!viewResult.Success)
            {
                throw new KeyNotFoundException($"Could not render the HTML, because {templateFileName} template does not exist");
            }

            try
            {
                var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary, tempDataDictionary, outputWriter, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);

                return outputWriter.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Could not render the HTML because of an error");

                return string.Empty;
            }
        }
    }
}
