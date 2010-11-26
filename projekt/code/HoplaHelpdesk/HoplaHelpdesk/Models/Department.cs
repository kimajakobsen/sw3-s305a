using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Models
{
    public partial class Department
    {
        public EntityCollection<IPerson> IPersons()
        {
            var IPersonSet = new EntityCollection<IPerson>();
            foreach (var person in Persons)
            {
                IPersonSet.Add(person);
            }
            return IPersonSet;
        }
    }
}