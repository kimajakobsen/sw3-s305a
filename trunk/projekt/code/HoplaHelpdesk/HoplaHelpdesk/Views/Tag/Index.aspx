<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HoplaHelpdesk.Models.Tag>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Description
            </th>
            <th>
                Priority
            </th>
            <th>
                Category_Id
            </th>
            <th>
                SolvedProblems
            </th>
            <th>
                TimeConsumed
            </th>
            <th>
                AverageTimeSpent
            </th>
            <th>
                Hidden
            </th>
            <th>
                IsSelected
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
                <%: item.Id %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.Priority %>
            </td>
            <td>
                <%: item.Category_Id %>
            </td>
            <td>
                <%: item.SolvedProblems %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.TimeConsumed) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.AverageTimeSpent) %>
            </td>
            <td>
                <%: item.Hidden %>
            </td>
            <td>
                <%: item.IsSelected %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

