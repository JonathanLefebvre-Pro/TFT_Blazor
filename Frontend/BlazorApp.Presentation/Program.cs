using BlazorApp.AppCore.Abstraction.Repositories;
using BlazorApp.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddHttpClient<IMoviesRepository, MoviesService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7282/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            await builder.Build().RunAsync();
        }
    }
}
