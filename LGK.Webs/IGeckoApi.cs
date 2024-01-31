using LGK.Library.ViewModels;
using Refit;

namespace LGK.Webs
{
    public interface IGeckoApi {
        [Get("/Gecko")]
        Task<List<GeckoViewModel>> GetGeckoList();
        
    }
}
