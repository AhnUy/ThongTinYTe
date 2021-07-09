using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ThongTinYTe.Controllers
{
    public class CityResultRecordsAPIController : Controller
    {
        private readonly HttpClient client = null;
        private string api;
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public CityResultRecordsAPIController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://data.opendevelopmentmekong.net/vi/api/3/action/datastore_search?resource_id=d2967df9-3ef2-4d86-ad21-c14becf043fc";
        }
    }
}