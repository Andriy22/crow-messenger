namespace Application.Interfaces
{
    public interface IRazorRenderService
    {
        public Task<string> RenderTemplateToStringAsync<T>(string template, T model);
    }
}
