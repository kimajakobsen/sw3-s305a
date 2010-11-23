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
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ })%> |
                <% } %>
                 <% if (Model.Deletable)
                   { %>
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
                 <% } %>
            </td>
            <td>
               <%: Html.ActionLink("Details", item.Title, new { /* id=item.PrimaryKey */ })%> |
            
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


