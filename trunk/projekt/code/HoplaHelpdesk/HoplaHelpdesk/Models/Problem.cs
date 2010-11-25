using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HoplaHelpdesk.Models
{

     [MetadataType(typeof(ProblemMetaData))]
    public partial class Problem : IProblem
    {
          
          
          public class ProblemMetaData
          {
              [Required(ErrorMessage = "A problem Title is required")]
              [StringLength(160)]
              public object Title { get; set; }


          }


         public short GetPriority(){
             if (Tags != null || Tags.Count == 0)
             {
                 short sum = 0;
                 foreach (var tag in Tags)
                 {
                     sum += tag.Priority;
                 }
                 return (short)(sum / (short)Tags.Count);
             }
             
             return 0;
         }
    }


     public interface IProblem
     {
         short GetPriority();


     }
}