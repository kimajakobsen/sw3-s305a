<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>
    <table>
        <tr>
            <th></th>
            <th>
                Workload
            </th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Per Problem
            </th>
             <th>
                Last Week
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
                <%: String.Format("{0:F}", item.Workload) %>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.AverageTimePerProblem() %>
            </td>
            <td>
                <%: item.AverageTimePerProblemLastWeek() %>
            </td>
          
        </tr>
    
    <% } %>

    </table>

