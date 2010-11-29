<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<int>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul>
        <li><%: Html.ActionLink("Add problem", "CategorizeNewProblem", "CreateProblem") %></li>
        <li><%: Html.ActionLink("My problems", "ViewProblems", new { id = Model })%></li>
        <li><%: Html.ActionLink("Search for problems", "ViewProblems") %></li>
    </ul>

</asp:Content>
