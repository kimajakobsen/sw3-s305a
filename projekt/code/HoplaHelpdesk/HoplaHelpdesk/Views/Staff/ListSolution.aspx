<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.AttachSolutionViewModel>"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListSolution
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ListSolution</h2>

    <table>
        <tr>
            <th></th>
            <th>
                ProblemID
            </th>
        </tr>

    <% foreach (var item in Model.Solutions) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Attach", "AttachSolution", new { id = Model.ProblemID, SolutionToAttach=item })%> 
            </td>
            <td>
                <%: item.Description %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

