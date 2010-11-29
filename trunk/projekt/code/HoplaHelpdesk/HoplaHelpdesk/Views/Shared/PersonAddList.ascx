<%@ Control Language="C#"   Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Name
            </th>
            <th>
                Email
            </th>
            <th>
                DepartmentId
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id, name=item.Name, email=item.Email }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.DepartmentId %>
            </td>
        </tr>
    
    <% } %>

    </table>




