﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthAmericasSkiResorts.DataAccessLayer
{
    public class DataSettings
    {
        public string dataFilePath = HttpContext.Current.Server.MapPath("~/App_Data/SkiResortsXmlData.xml");
    }
}