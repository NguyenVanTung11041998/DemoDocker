using System.Threading.Tasks;

namespace DockerDemo.Services
{
    public interface ITemplateAppService
    {
        Task<string> RenderAsync<TViewModel>(string templateFileName, TViewModel viewModel);
    }
}
