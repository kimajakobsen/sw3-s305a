<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CommentListViewModel>" %>

    <table class="problemlist">
        <tr>
            <% if (Model.Deletable) { %><th></th> <% } %>

            <th>
                time
            </th>
            <th>
                description
            </th>
        </tr>

    <% foreach (var item in Model.Comments) { %>
    
        <tr>
        <% if (Model.Deletable)
           { %>
            <td>
                <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td>
            <% } %>
            <td>
                <%: String.Format("{0:g}", item.time) %>
            </td>
            <td>
                <%: item.description %>
            </td>
        </tr>
    
    <% } %>

    </table>

