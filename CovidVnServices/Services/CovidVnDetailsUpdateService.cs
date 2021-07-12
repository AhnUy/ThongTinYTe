using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ThongTinYTe.CovidVnServices.Interfaces;
using ThongTinYTe.CovidVnServices.Models;

namespace ThongTinYTe.CovidVnServices.Services
{
    public class CovidVnDetailsUpdateService : BackgroundService
    {
        private readonly ILogger<CovidVnDetailsUpdateService> _logger;
        private readonly ICovidVnDetailsService _service;
        private readonly HttpClient client = null;
        private string api;
        public CovidVnDetailsUpdateService(ILogger<CovidVnDetailsUpdateService> logger, ICovidVnDetailsService service) {
            this._service = service;
            this._logger = logger;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://data.opendevelopmentmekong.net/vi/api/3/action/datastore_search?resource_id=311599a4-664f-4205-b17a-777e5eb6b3e1&sort=ID%20desc";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) {
                HttpResponseMessage response = await client.GetAsync(api);
                string rawdata = await response.Content.ReadAsStringAsync();
                CaseAPI obj = JsonConvert.DeserializeObject<CaseAPI>(rawdata);
                if (obj.success) {
                    var records = obj.result.records;
                    var total = obj.result.total;
                    _service.ReplaceRecords(records);
                    _logger.LogInformation($"Updated The CovidVN Cases: {total} cases");
                } else {
                    _logger.LogInformation("Cannot load the data");
                }
                await Task.Delay(1000 * 30);
            }
        }
    }
}