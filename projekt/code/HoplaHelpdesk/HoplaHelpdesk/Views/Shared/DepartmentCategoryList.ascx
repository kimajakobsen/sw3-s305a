<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Category>>" %>


    <% foreach (var item in Model) { %>
    

               <p><%: Html.ActionLink(item.Name, "Details", "Category", new { item.Id }, null)%></p> 
             
               

    <% } %>

 

