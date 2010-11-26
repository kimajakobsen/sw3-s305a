<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admin interface</h2>

     <ul>
    <li>
    <p><%: Html.ActionLink("Administrate departments, categories and tags", "Index", "Department")%></p>
    <p><%: Html.ActionLink("Person Administrate", "Index","person")%></p>
    
    </li>

    
    </ul>

</asp:Content>
