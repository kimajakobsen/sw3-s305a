<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

 

    <% foreach (var item in Model) { %>
    
        <% if (item.IsStaff() == true){ %>
                <%: item.Name %>
                <%} %>

    <% } %>

   

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>


