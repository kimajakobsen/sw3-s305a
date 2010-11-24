<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Comment>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                time
            </th>
            <th>
                description
            </th>
            <th>
                Problem_Id
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.time) %>
            </td>
            <td>
                <%: item.description %>
            </td>
            <td>
                <%: item.Problem_Id %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>


