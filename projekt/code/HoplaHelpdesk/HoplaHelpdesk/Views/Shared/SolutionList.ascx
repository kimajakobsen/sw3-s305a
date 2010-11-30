<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.SolutionListViewModel>" %>

    <table class="problemlist" width="100%">
        <tr>
            <% if (Model.Deletable) { %>   <th></th> <% } %>
            <th>
                Solutions
            </th>
        </tr>

    <% foreach (var item in Model.Solutions) { %>
    
        <tr>
            <% if (Model.Deletable) { %>       
            <td>
                 <%: Html.ActionLink("Detach", "DetachSolution", new { id = Model.Problem.Id, solutionID = item.Id})%>
                
            </td>
            <% } %>
            <td>
                <%: item.Description %>
            </td>
        </tr>
    
    <% } %>

    </table>

