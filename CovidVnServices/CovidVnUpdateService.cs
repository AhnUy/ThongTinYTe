using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ThongTinYTe.CovidVnServices.Models;

namespace ThongTinYTe.CovidVnServices
{
    public class CovidVnUpdateService : BackgroundService
    {
        private readonly ILogger<CovidVnUpdateService> _logger;
        private readonly ICovidVnService _service;
        private readonly HttpClient client = null;
        private string api;
        public CovidVnUpdateService(ILogger<CovidVnUpdateService> logger, ICovidVnService service) {
            this._service = service;
            this._logger = logger;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://data.opendevelopmentmekong.net/api/3/action/datastore_search?resource_id=d2967df9-3ef2-4d86-ad21-c14becf043fc";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) {
                HttpResponseMessage response = await client.GetAsync(api);
                string rawdata = await response.Content.ReadAsStringAsync();
                ProvinceAPI obj = JsonConvert.DeserializeObject<ProvinceAPI>(rawdata);
                if (obj.success) {
                    var records = obj.result.records;
                    _service.ReplaceRecords(records);
                    _logger.LogInformation($"Updated The CovidVN Records: {records.Count} provinces");
                } else {
                    _logger.LogInformation("Cannot load the data");
                }
                await Task.Delay(1000 * 30);
            }
        }
    }
}