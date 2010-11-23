<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

    <table>
        <tr>
            <th></th>
        </tr>

    <% foreach (var item in Model.Problems) { %>
    
        <tr>
            <td>
                <% if (Model.Editable)
                   { %>
                <%: Html.ActionLink("Edit", "Edit", new { item.Title })%> |
                <% } %>
                 <% if (Model.Deletable)
                   { %>
                <%: Html.ActionLink("Delete", "Delete", new { item.Title })%>
                 <% } %>
            </td>
            <td>
               <%: Html.ActionLink("Details", "Delete", new { item.Title })%> |
            
            </td>
            <td>
                <%: item.Title %>
            </td>
        </tr>
        <tr>
            <td colspan="2">   <%: item.Description %> </td>
        
        </tr>
    
    <% } %>

    </table>


