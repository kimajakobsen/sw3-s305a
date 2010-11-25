<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Department>>" %>

 
 Select a department
    <% foreach (var item in Model) { %>
       
               <p><%:  Html.ActionLink(item.DepartmentName, "Edit", new { item.DepartmentName })%></p> 

    <% } %>

   


