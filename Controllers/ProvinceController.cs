using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ThongTinYTe.CovidVnServices.Interfaces;
using ThongTinYTe.CovidVnServices.Models;
namespace ThongTinYTe.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly ICovidVnService _service = null;

        public ProvinceController(ICovidVnService service) {
            this._service = service;
        }

        public IActionResult Index() {
            List<ProvinceRecord> records = new List<ProvinceRecord>(_service.GetRecords());
            records.Sort((r1, r2) => r1.Province.CompareTo(r2.Province));
            ViewData["Provinces"] = records;
            return View(records);
        }
    }
}