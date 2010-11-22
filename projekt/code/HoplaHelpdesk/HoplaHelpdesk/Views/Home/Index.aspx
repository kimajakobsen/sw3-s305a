<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <p>
        <ul>
        <li><%: Html.ActionLink("Client", "Index", "Client")  %></li>
        <li><%: Html.ActionLink("Staff", "Index", "Staff")  %></li>
        <li><%: Html.ActionLink("Admin", "Index", "Admin")  %></li>
        </ul>
        
    </p>
</asp:Content>
