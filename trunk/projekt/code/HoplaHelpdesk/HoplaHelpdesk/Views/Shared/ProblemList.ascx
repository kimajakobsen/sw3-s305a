<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

    <table class="problemlist">
            <tr>
                <th width="20%">Title</th>
                <th width="10%">Deadline</th>
                <th width="10%">Priority</th>
                <th width="10%">ETA</th>
                <th width="50%">Description</th>
            </tr>
    <% foreach (var item in Model.Problems) { %>        
            <tr>
                <td>
                    <%:  Html.ActionLink(item.Title, "Details", new { item.Id })%>
                </td>
                <td><%: item.Deadline %></td>
                <td></td>
                <td></td>
                <td><%: item.Description %></td>
            </tr>
    <% } %>
    </table>




