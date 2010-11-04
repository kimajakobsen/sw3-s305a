using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Record_Shop.Controllers
{
    public class HelloWorldController : Controller
    {
        public string index()
        { 
            return "index hej hej";
        }

        public string HelloWorld()
        {
            return "Hello World";
        }

    }
}
