using LiveMedTest.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiveMedTest.WebFront.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;



        public List<UserCountry> Items { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            using (var client  = _httpClientFactory.CreateClient("LiveMedBackend"))
            {
                var response = await client.GetAsync("/api/UserCountry");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserCountry>>(content);

                }


               
            }
        }
    }
}