<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admin interface</h2>

     <ul>
    <li>
    <%: Html.ActionLink("Administrate departments, categories and tags", "AdministrateDepartments") %>
    
    </li>

    
    </ul>

</asp:Content>
