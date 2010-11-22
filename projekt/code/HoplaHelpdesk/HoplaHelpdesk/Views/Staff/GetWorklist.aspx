<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HoplaHelpdesk.Models.Problem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	GetWorklist
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GetWorklist</h2>

    <table>
        <tr>
            <th></th>
        </tr>
        <%
            // Get worklist - henter liste med alle problemer, hvis assignment matcher nuværende staff's staffID
            // TODO: FIX accounting og staffID så det virker med hans eget ID og ikke myownStaffId
        %>
    <%  foreach (var item in Model) { %>
        <% if  (item.Assignmet == "myownStaffId") { %>
        <tr>
            <td>
            
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }) %>

                
            </td>
            <td>
                <%: item.Title %>
            </td>
        </tr>
        <% } %>
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

