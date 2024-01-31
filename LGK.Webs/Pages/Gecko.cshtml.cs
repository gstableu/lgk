using LGK.Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace LGK.Webs.Pages
{
    public class GeckoModel : PageModel
    {
        private readonly ILogger<GeckoModel> _logger;

        public string? Name { get; set; }
        public string? MyProperty { get; set; }

        public List<GeckoViewModel> List { get; set; }
        public GeckoModel(ILogger<GeckoModel> logger)
        {
            _logger = logger;
        }
        public async Task OnGet()
        {
            var svc = RestService.For<IGeckoApi>("https://localhost:8002");
            List = await svc.GetGeckoList();
        }
    }
}
