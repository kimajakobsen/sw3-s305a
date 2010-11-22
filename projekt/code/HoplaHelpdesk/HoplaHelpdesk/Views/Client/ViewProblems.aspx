<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HoplaHelpdesk.Models.Problem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewProblems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewProblems</h2>

    <table>
        <tr>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
            
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> 
          
            </td>
            <td>
                <%: item.Title %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "CategorizeNewProblem") %>
    </p>

</asp:Content>

