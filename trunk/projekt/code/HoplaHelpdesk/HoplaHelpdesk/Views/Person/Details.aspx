<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

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
                Email
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Add", "Edit") %> |
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Email %>
            </td>

        </tr>
    
    <% } %>

    </table>

</asp:Content>

