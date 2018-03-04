using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using NorthAmericasSkiResorts.Models;
using NorthAmericasSkiResorts.DataAccessLayer;


namespace NorthAmericasSkiResorts.Controllers
{
    public class SkiResortController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder, int? page)
        {

            SkiResortRepository skiResortRepository = new SkiResortRepository();

            ViewBag.Cities = ListOfCities();

            IEnumerable<SkiResort> skiResorts;
            using (skiResortRepository)
            {
                skiResorts = skiResortRepository.SelectAll() as IList<SkiResort>;
            }

            switch (sortOrder)
            {
                case "Name":
                    skiResorts = skiResorts.OrderBy(s => s.Name);
                    break;
                case "City":
                    skiResorts = skiResorts.OrderBy(s => s.City);
                    break;
                case "State":
                    skiResorts = skiResorts.OrderBy(s => s.State);
                    break;
                default:
                    skiResorts = skiResorts.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            skiResorts = skiResorts.ToPagedList(pageNumber, pageSize);

            return View(skiResorts);

        }

        [HttpPost]
        public ActionResult Index(string searchCriteria, string cityFilter, int? page)
        {

            SkiResortRepository SkiResortRepository = new SkiResortRepository();

            ViewBag.Cities = ListOfCities();

            IEnumerable<SkiResort> skiResorts;
            using (SkiResortRepository)
            {
                skiResorts = SkiResortRepository.SelectAll() as IList<SkiResort>;
            }

            if (searchCriteria != null)
            {
                skiResorts = skiResorts.Where(SkiResort => SkiResort.Name.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            if(cityFilter != "" || cityFilter == null)
            {
                skiResorts = skiResorts.Where(s => s.City == cityFilter);
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            skiResorts = skiResorts.ToPagedList(pageNumber, pageSize);

            return View(skiResorts);
        }

        [NonAction]
        private IEnumerable<string> ListOfCities()
        {

            SkiResortRepository skiResortRepository = new SkiResortRepository();

            IEnumerable<SkiResort> skiResorts;
            using (skiResortRepository)
            {
                skiResorts = skiResortRepository.SelectAll() as IList<SkiResort>;
            }

      
            var cities = skiResorts.Select(skiResort => skiResort.City).Distinct().OrderBy(x => x);

            return cities;
        }

        public ActionResult Details(int id)
        {
            SkiResortRepository skiResortRepository = new SkiResortRepository();
            SkiResort skiResort = new SkiResort();

            using (skiResortRepository)
            {
                skiResort = skiResortRepository.SelectOne(id);
            }

            return View(skiResort);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SkiResort skiResortCollection)
        {
            try
            {
                SkiResortRepository Repository = new SkiResortRepository();

                using (Repository)
                {
                    Repository.Insert(skiResortCollection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SkiResortRepository srRepository = new SkiResortRepository();
            SkiResort skiResort = new SkiResort();

            using (srRepository)
            {
                skiResort = srRepository.SelectOne(id);
            }

            return View(skiResort);
        }

        [HttpPost]
        public ActionResult Edit(SkiResort skiResort)
        {
            try
            {
                SkiResortRepository srRepository = new SkiResortRepository();

                using (srRepository)
                {
                    srRepository.Update(skiResort);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            SkiResortRepository srRepository = new SkiResortRepository();
            SkiResort skiResort = new SkiResort();

            using (srRepository)
            {
                skiResort = srRepository.SelectOne(id);
            }

            return View(skiResort);
        }

        [HttpPost]
        public ActionResult Delete(int id, SkiResort skiResort)
        {
            try
            {
                SkiResortRepository srRepository = new SkiResortRepository();

                using (srRepository)
                {
                    srRepository.Delete(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}