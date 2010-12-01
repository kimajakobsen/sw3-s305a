<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.SimilairProblemListViewModel>" %>
    <table class="problemlist" width="90%">
            <tr>
                <th width="20%">Title</th>
                <th width="20%">Deadline</th>
                <th width="10%">ETA</th>
                <th width="40%">Description</th>
            </tr>
    <% foreach (var item in Model.Problems) { %>        
            <tr>
                <td>
                    <%:  Html.ActionLink(item.Title, "Details", new { item.Id })%>
                </td>
                <td><% if (item.IsDeadlineApproved == true) { %>  <%: String.Format("{0:g}", item.Deadline) %>  <% } %></td>
                <td><%: String.Format("{0:g}", item.Eta) %></td>
                <td><%: item.Description %></td>
            </tr>
    <% } %>
    </table>




