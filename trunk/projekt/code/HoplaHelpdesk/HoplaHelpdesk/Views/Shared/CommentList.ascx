<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CommentListViewModel>" %>

    <table class="problemlist">
        <tr>

            <th>
                time
            </th>
            <th>
                description
            </th>
        </tr>

    <% foreach (var item in Model.Comments) { %>
    
        <tr>
            <td>
                <%: String.Format("{0:g}", item.time) %>
            </td>
            <td>
                <%: item.description %>
            </td>
        </tr>
    
    <% } %>

    </table>

