using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class CommentListViewModel
    {
        public List<Comment> Comments { get; set; } // list of problems already added
    }
}