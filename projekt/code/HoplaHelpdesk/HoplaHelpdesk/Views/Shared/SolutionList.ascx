<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.SolutionListViewModel>" %>

    <table class="problemlist">
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
                 <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
                
            </td>
            <% } %>
            <td>
                <%: item.Description %>
            </td>
        </tr>
    
    <% } %>

    </table>

