using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Record_Shop.Controllers
{
    public class HelloWorld : Controller
    {
        public string index()
        {
            return "This is the standard response....";
        }

        public string HelloWholeWorld()
        {
            return "Hello World";
        }
    }
}
