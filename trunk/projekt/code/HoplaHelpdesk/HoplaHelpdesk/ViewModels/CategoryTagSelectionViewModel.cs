using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.ViewModels
{
    public class CategoryTagSelectionViewModel
    {
        public EntityCollection<Category> Categories {get;set;}

    }
}