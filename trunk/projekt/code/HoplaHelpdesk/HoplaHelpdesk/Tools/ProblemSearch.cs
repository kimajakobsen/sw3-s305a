using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Tools
{
    public static class ProblemSearch
    {
        private ProblemSearch();


        public static List<Problem> Search(CategoryTagSelectionViewModel catTag)
        {

            return new List<Problem>(){ 
                new Problem(){
                    Title = "Something with coms",
                    Description = "fvæjkeghlergjgehtiegtqhgetkijguiggergeggegtelgqerhjgtfoikeuwui   rfgeruhriuugeuiouiguihgerqueuieighequiheqruihvushfsdvbdkjfvefdg"
                    
                },
                 new Problem(){
                    Title = "Somethjlkjlkjlkjlkjlkj",
                    Description = "fvæjkegj hjhkjh hkj h kjh kjh kjh kjh kjh kjh  kjh  kjh hlergjgehtiegtqhgetkijguiggergeggegtelgqerhjgtfoikeuwui   rfgeruhriuugeuiouiguihgerqueuieighequiheqruihvushfsdvbdkjfvefdg"
                    
                }

            };
        }

    }
}