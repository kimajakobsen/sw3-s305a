<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Helpers.Department>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                DepartmentName
            </th>
            <th>
                Description
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.DepartmentName %>
            </td>
            <td>
                <%: item.Description %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>


