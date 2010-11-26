<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

    <table>
        <tr>
            <th></th>
      
            <th>
                Name
            </th>

        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>            
                <%: Html.ActionLink("Assign", "Assign", new { id=item.Id,dept=item.DepartmentId })%>
            </td>
            <td>
                <%: item.Name %>
            </td>
        </tr>
    
    <% } %>

    </table>

