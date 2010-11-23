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
        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, DBEntities db)
        {
            /*
            var probs = new List<Problem>(){ 
                new Problem(){
                    Title = "Something with coms",
                    Description = "fvæjkeghlergjgehtiegtqhgetkijguiggergeggegtelgqerhjgtfoikeuwui   rfgeruhriuugeuiouiguihgerqueuieighequiheqruihvushfsdvbdkjfvefdg"
                    
                },
                 new Problem(){
                    Title = "Somethjlkjlkjlkjlkjlkj",
                    Description = "fvæjkegj hjhkjh hkj h kjh kjh kjh kjh kjh kjh  kjh  kjh hlergjgehtiegtqhgetkijguiggergeggegtelgqerhjgtfoikeuwui   rfgeruhriuugeuiouiguihgerqueuieighequiheqruihvushfsdvbdkjfvefdg"
                    
                }

            };*/

            List<Problem> result;

            var temp = db.ProblemSet;
            foreach(Tag tag in catTag.AllTags())
            {
                temp = (System.Data.Objects.ObjectSet<Problem>)temp.Where(x => x.Tags.Contains(tag));
            }

            result = temp.ToList();

            return result;
        }

    }
}