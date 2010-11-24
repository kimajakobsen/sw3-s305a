<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

    

    <% foreach (var item in Model.Problems) { %>
    

        <table border="1">
            <tr>
                <th width="10%">Deadline</th>
                <th width="10%">Priority</th>
                <th width="10%">ETA</th>
                <th width="20%">Title</th>
                <th width="50%">Description</th>
            </tr>
            <tr>
                <td><%: item.Deadline %></td>
                <td></td>
                <td></td>
                <td><%:  Html.ActionLink(item.Title, "Details", new { item.Id })%></th></td>
                <td><%: item.Description %></td>
            </tr>
        </table>

    <% } %>




