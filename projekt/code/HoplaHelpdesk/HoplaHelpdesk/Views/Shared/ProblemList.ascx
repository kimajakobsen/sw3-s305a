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
                <%: Html.ActionLink("Edit", "Edit", new { item.Id })%> |
                <% } %>
                 <% if (Model.Deletable)
                   { %>
                <%: Html.ActionLink("Delete", "Delete", new { item.Id })%>
                 <% } %>
            </td>
            <td>
               <%: Html.ActionLink("Details", "Delete", new { item.Id })%> |
            
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


