<%@ Control Language="C#"   Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

    <table class="problemlist" width="90%">
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Email
            </th>
            <th>
                DepartmentId
            </th>
            <th>
                Workload
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit","Person", new { id=item.Id },null) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td><% if (item.Department != null)
                   { %>
                <%: item.Department.Name%>
            </td>
             <td>
                <%: item.GetWorkload()%>
            </td>
            <% } %>
        </tr>
    
    <% } %>

    </table>




