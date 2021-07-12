using System.Collections.Generic;
using ThongTinYTe.CovidVnServices.Models;

namespace ThongTinYTe.CovidVnServices.Interfaces
{
    public interface ICovidVnDetailsService
    {
        void ReplaceRecords(IEnumerable<CaseRecord> records);
        IEnumerable<CaseRecord> GetRecords();
    }
}