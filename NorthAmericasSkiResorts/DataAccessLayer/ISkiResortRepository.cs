using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NorthAmericasSkiResorts.Models;

namespace NorthAmericasSkiResorts.DataAccessLayer
{
    public interface ISkiResortDataService
    {
        List<SkiResort> Read();
        void Write(List<SkiResort> SkiResorts);
    }
}