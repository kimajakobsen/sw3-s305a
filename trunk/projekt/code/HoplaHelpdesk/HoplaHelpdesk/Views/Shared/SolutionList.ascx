<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.SolutionListViewModel>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Description
            </th>
        </tr>

    <% foreach (var item in Model.Solutions) { %>
    
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
                <%: item.description %>
            </td>
        </tr>
    
    <% } %>

    </table>

