<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemDetailsCommentListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ProblemDetailsWithAttach
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <fieldset>
        <legend><%: Model.Problem.Title %></legend>
        
        <% Html.RenderPartial("ProblemDetails", Model.Problem); %>
        <br />
        <h2>Solutions:</h2>

        <% Html.RenderPartial("SolutionListWithAttach", Model.Solutionlistviewmodel,ViewData); %>
        <br />
        <h2>Comments:</h2>
        
        <% Html.RenderPartial("CommentList", Model.Commentlistviewmodel); %>

    </fieldset>

</asp:Content>
