using Microsoft.AspNetCore.Mvc;
using ThongTinYTe.CovidVnServices.Interfaces;

namespace ThongTinYTe.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly ICovidVnService _service = null;

        public ProvinceController(ICovidVnService service) {
            this._service = service;
        }

        public IActionResult Index() {
            return View(_service.GetRecords());
        }
    }
}