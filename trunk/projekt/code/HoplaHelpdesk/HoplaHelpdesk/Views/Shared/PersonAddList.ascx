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
                Department name
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Add", "ChangeDepartment", new { DepId = ViewData["homeDepartment"], PerId = item.Id}) %> |
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




