using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThongTinYTe.Models;

namespace ThongTinYTe.Controllers
{
    public class CaseResultRecordsAPIController : Controller
    {
        private readonly HttpClient client = null;
        private string api;
        private string sort;
        private string limit;
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public CaseResultRecordsAPIController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://data.opendevelopmentmekong.net/vi/api/3/action/datastore_search?resource_id=311599a4-664f-4205-b17a-777e5eb6b3e1";
            this.sort = "&sort=ID%20desc";
            this.limit = "&limit=1";
        }

        public IActionResult KhaiBaoToanDan()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> KhaiBaoToanDan(CaseResultRecordsAPI people)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.GetAsync($"{api}{sort}{limit}");
                string rawdata = await response.Content.ReadAsStringAsync();
                CaseAPI Case = JsonConvert.DeserializeObject<CaseAPI>(rawdata);

                // Hiện cảnh báo
                return View(Case.result.records[0]);
            }
            return NotFound("Hello world!");
        }
    }
}