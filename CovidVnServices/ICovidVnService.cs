using System.Collections.Generic;
using ThongTinYTe.CovidVnServices.Models;

namespace ThongTinYTe.CovidVnServices
{
    public interface ICovidVnService
    {
        void ReplaceRecords(IEnumerable<ProvinceRecord> records);
        IEnumerable<ProvinceRecord> GetRecords();
    }
}