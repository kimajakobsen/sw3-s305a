<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CommentListViewModel>" %>

    <table width="100%" class="problemlist">
        <tr>

            <th width="10%">
                time
            </th>
            <th width="90%">
                description
            </th>
        </tr>

    <% foreach (var item in Model.Comments) { %>
    
        <tr>
            <td>
                <%: String.Format("{0:g}", item.time) %>
            </td>
            <td>
                <%: item.PersonsName %>
            </td>
            <td>
                <%: item.description %>
            </td>

        </tr>
    
    <% } %>

    </table>

