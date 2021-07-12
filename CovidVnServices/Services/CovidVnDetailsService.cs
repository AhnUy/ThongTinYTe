using System.Collections.Concurrent;
using System.Collections.Generic;
using ThongTinYTe.CovidVnServices.Interfaces;
using ThongTinYTe.CovidVnServices.Models;

namespace ThongTinYTe.CovidVnServices.Services
{
    public class CovidVnDetailsService : ICovidVnDetailsService
    {
        private readonly ConcurrentBag<CaseRecord> _records = null;

        public CovidVnDetailsService() {
            _records = new ConcurrentBag<CaseRecord>();
        }
        public IEnumerable<CaseRecord> GetRecords()
        {
            return _records;
        }
        public void ReplaceRecords(IEnumerable<CaseRecord> records)
        {
            this._records.Clear();
            foreach (var record in records) {
                this._records.Add(record);
            }
        }
    }
}