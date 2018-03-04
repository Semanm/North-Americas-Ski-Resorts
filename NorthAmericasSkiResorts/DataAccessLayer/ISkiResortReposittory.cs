using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NorthAmericasSkiResorts.Models;

namespace NorthAmericasSkiResorts.DataAccessLayer
{
    public interface ISkiResortRepository
    {
        IEnumerable<SkiResort> SelectAll();
        SkiResort SelectOne(int id);
        void Insert(SkiResort skiResort);
        void Update(SkiResort skiResort);
        void Delete(int id);
    }
}