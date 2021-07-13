using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThongTinYTe.CovidVnServices.Interfaces;
using ThongTinYTe.CovidVnServices.Models;
using ThongTinYTe.Models;

namespace ThongTinYTe.Controllers
{
    public class CaseController : Controller
    {
        private readonly ICovidVnDetailsService _service_detail = null;
        private readonly ICovidVnService _service = null;
        public CaseController(ICovidVnService service, ICovidVnDetailsService service_detail)
        {
            this._service = service;
            this._service_detail = service_detail;
        }

        // public IActionResult Index() {
        //     return View(_service_detail.GetRecords());
        // }

        public async Task<IActionResult> KhaiBaoToanDan()
        {
            // Lấy danh sách thành phố ở Việt Nam từ service
            IEnumerable<ProvinceRecord> records = _service.GetRecords();
            List<string> city_list = new List<string>();
            foreach (ProvinceRecord record in records)
            {
                city_list.Add(record.Province);
            }
            ViewBag.cities = city_list;

            // Lấy danh sách quốc gia từ api
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            string countries_api = "https://restcountries.eu/rest/v2/all";
            HttpResponseMessage response_countries_api = await client.GetAsync(countries_api);
            string raw_cities = await response_countries_api.Content.ReadAsStringAsync();
            List<CountriesAPI> countries_object = JsonConvert.DeserializeObject<List<CountriesAPI>>(raw_cities);
            List<string> countries_list = new List<string>();
            foreach (var country in countries_object)
            {
                countries_list.Add(country.name);
            }
            ViewBag.countries = countries_list;

            return View();
        }
        [HttpPost]
        public IActionResult KhaiBaoToanDan(KhaiBaoToanDan people)
        {
            IEnumerable<CaseRecord> records = _service_detail.GetRecords();
            foreach (CaseRecord record in records)
            {
                if (record.Location == people.tinh_thanh)
                {
                    return View("CanhBaoKhuVuc");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> KhaiBaoDiChuyen()
        {
            // Lấy danh sách thành phố ở Việt Nam từ service
            IEnumerable<ProvinceRecord> records = _service.GetRecords();
            List<string> city_list = new List<string>();
            foreach (ProvinceRecord record in records)
            {
                city_list.Add(record.Province);
            }
            ViewBag.cities = city_list;
            // Lấy danh sách quốc gia từ api
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            string countries_api = "https://restcountries.eu/rest/v2/all";
            HttpResponseMessage response_countries_api = await client.GetAsync(countries_api);
            string raw_cities = await response_countries_api.Content.ReadAsStringAsync();
            List<CountriesAPI> countries_object = JsonConvert.DeserializeObject<List<CountriesAPI>>(raw_cities);
            List<string> countries_list = new List<string>();
            foreach (var country in countries_object)
            {
                countries_list.Add(country.name);
            }
            ViewBag.countries = countries_list; 

            return View();
        }
        [HttpPost]
        public IActionResult KhaiBaoDiChuyen(KhaiBaoDiChuyen traveler)
        {
            IEnumerable<CaseRecord> records = _service_detail.GetRecords();
            foreach (CaseRecord record in records)
            {
                if (record.Location == traveler.noi_di || record.Location == traveler.noi_den)
                {
                    return View("CanhBaoCachLy");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
    public class CountriesAPI
    {
        public string name { get; set; }
    }
}