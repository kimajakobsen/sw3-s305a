<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CommentListViewModel>" %>

    <table class="problemlist">
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

    <% foreach (var item in Model.Comments) { %>
    
        <tr>
        <% if ( %>
            <td>
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: String.Format("{0:g}", item.time) %>
            </td>
            <td>
                <%: item.description %>
            </td>
        </tr>
    
    <% } %>

    </table>

