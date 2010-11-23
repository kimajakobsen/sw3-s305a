<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Similar Problems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Similar Problems</h2>
    <% Html.RenderPartial("ProblemList", Model); %>

    <p>
       <%: Html.ActionLink("No problem Suffice", "Create") %>
    </p>

</asp:Content>
