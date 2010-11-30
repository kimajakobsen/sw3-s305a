using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{
    public static class Constants
    {
        //Put every constant in here
        public static readonly int MinimumNumberProblemsForSearch = 10;
        public static readonly string ConnectionStringLocal = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
        public static readonly string ConnectionStringGlobal = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
    }
}