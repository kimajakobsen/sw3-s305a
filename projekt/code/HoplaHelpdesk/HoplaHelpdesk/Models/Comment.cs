using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text;

namespace HoplaHelpdesk.Models
{
    public partial class Comment
    {
        public string PersonsName
        {
            get
            {
                hoplaEntities db = new hoplaEntities();
                return db.PersonSet.FirstOrDefault(y => y.Id == PersonsId).Name;         
            }
            private set { }
        }

    }
}