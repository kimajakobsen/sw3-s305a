<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Client interface</h2>

    <ul>
    <li>
    <%: Html.ActionLink("Add problem", "CategorizeNewProblem") %>
    </li>
    <li>
    <%: Html.ActionLink("View problems", "ViewProblems") %>
    </li>
    </ul>

</asp:Content>
