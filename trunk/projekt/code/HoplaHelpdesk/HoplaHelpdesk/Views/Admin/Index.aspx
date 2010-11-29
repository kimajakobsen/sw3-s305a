<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul>
        <li><%: Html.ActionLink("Administrate departments, categories and tags", "Index", "Department")%></li>
        <li><%: Html.ActionLink("Person Administrate", "Index","person")%></li>
    </ul>

</asp:Content>
