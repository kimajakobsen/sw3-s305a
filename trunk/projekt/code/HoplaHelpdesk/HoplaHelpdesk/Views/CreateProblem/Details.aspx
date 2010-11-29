<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.Models.Problem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <% Html.RenderPartial("ProblemDetails", Model); %>
    <%: Html.ActionLink("Subscribe to this problem", "Subscribe", new {PerId = ViewData["LoggedUser"] , ProId = Model.Id })%>
</asp:Content>
