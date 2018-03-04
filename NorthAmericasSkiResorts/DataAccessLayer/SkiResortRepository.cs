using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NorthAmericasSkiResorts.Models;

namespace NorthAmericasSkiResorts.DataAccessLayer
{
    public class SkiResortRepository : ISkiResortRepository, IDisposable
    {
        private List<SkiResort> _skiResorts;

        public SkiResortRepository()
        {
            SkiResortXmlDataService SkiResortXmlDataService = new SkiResortXmlDataService();

            using (SkiResortXmlDataService)
            {
                _skiResorts = SkiResortXmlDataService.Read() as List<SkiResort>;
            }
        }

        public IEnumerable<SkiResort> SelectAll()
        {
            return _skiResorts;
        }

        public SkiResort SelectOne(int id)
        {
            //SkiResort selectedSkiResort =
            //(from SkiResort in _skiResorts
            // where SkiResort.Id == id
            // select SkiResort).FirstOrDefault();

            SkiResort selectedSkiResort = _skiResorts.Where(p => p.Id == id).FirstOrDefault();

            return selectedSkiResort;
        }

        public void Insert(SkiResort SkiResort)
        {
            SkiResort.Id = NextIdValue();
            _skiResorts.Add(SkiResort);

            Save();
        }

        private int NextIdValue()
        {
            int currentMaxId = _skiResorts.OrderByDescending(b => b.Id).FirstOrDefault().Id;
            return currentMaxId + 1;
        }

        public void Update(SkiResort UpdateSkiResort)
        {
            var oldSkiResort = _skiResorts.Where(b => b.Id == UpdateSkiResort.Id).FirstOrDefault();

            if (oldSkiResort != null)
            {
                _skiResorts.Remove(oldSkiResort);
                _skiResorts.Add(UpdateSkiResort);
            }

            Save();
        }
        public void Delete(int id)
        {
            var SkiResort = _skiResorts.Where(b => b.Id == id).FirstOrDefault();

            if (SkiResort != null)
            {
                _skiResorts.Remove(SkiResort);
            }

            Save();
        }

        public void Save()
        {
            SkiResortXmlDataService SkiResortXmlDataService = new SkiResortXmlDataService();

            using (SkiResortXmlDataService)
            {
                SkiResortXmlDataService.Write(_skiResorts);
            }
        }

        public void Dispose()
        {
            _skiResorts = null;
        }
    }
}