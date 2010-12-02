<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.SolutionListViewModel>" %>

    <table class="problemlist" width="100%">
        <tr>
            <th>
                Solutions
            </th>
        </tr>

    <% foreach (var item in Model.Solutions) { %>
    
        <tr>      
            <td>
                 <%: Html.ActionLink("Attach", "AttachSolution", new { id = (HoplaHelpdesk.Models.Problem)ViewData["AttachToProblem"], solutionID = item.Id })%>
            </td>
            <td>
                <%: item.Description %>
            </td>
        </tr>
    
    <% } %>

    </table>

