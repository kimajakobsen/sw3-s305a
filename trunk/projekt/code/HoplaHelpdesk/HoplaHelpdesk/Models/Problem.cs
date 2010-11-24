﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoplaHelpdesk.Models
{

      [MetadataType(typeof(ProblemMetaData))]
    public partial class Problem
    {


          public class ProblemMetaData
          {
              [Required(ErrorMessage = "An Album Title is required")]
              [StringLength(160)]
              public object Title { get; set; }
          }
    }
}