using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{
    public static class Constants
    {
        //Put every constant in here
        public const int MinimumNumberProblemsForSearch = 10;
        public const string ConnectionStringLocal = "Data Source=win-k5l8cpbier1;Initial Catalog=hopla;User Id=John;Password=Trekant01";
        public const string ConnectionStringGlobal = "Data Source=81.209.164.151,61433;Initial Catalog=hopla;User Id=John;Password=Trekant01";
        public static string ConnectionString
        {
            get
            { 
                //return ConnectionStringGlobal;
                return ConnectionStringLocal;
            }
        }
        public const string RootName = "root";
        public const string RootPassword = "Trekant01";
        public const string AdminRoleName = "Admin";
        public const string StaffRoleName = "Staff";
        public const string ClientRoleName = "Client";
        
    }
}