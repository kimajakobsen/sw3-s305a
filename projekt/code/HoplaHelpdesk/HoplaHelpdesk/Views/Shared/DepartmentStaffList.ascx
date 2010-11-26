<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

 

    <% foreach (var item in Model) { %>

        <p><%:  Html.ActionLink(item.Name, "EditStaff","Staff", new { item.Id  },null)%></p> 

    <% } %>


       

   

  

