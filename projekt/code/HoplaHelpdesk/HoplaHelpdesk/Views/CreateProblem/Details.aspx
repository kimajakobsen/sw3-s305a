<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ClientProblemDetailsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Model.Problem.Title %></h2>

    <% Html.RenderPartial("ProblemDetails", Model.Problem); %><br /><br />
    <% Html.RenderPartial("SolutionList", Model.Solutionlistviewmodel); %><br /><br />
    
    <h2>Comments</h2>
    <% Html.RenderPartial("CommentList", Model.Commentlistviewmodel); %><br /><br />

    <h2>Add Comment</h2>
    <% Html.RenderPartial("ClientCommentCreate", Model); %>


    <br /><br />
    <% if (Model.Problem.Persons.FirstOrDefault(x => x.Id == (int)ViewData["LoggedUser"]) == null)
       { %>
    <%: Html.ActionLink("Subscribe to this problem", "Subscribe", new { PerId = ViewData["LoggedUser"], ProId = Model.Problem.Id })%>
   <%  }
       else
       { %>
    <%: Html.ActionLink("Unsubscribe to this problem", "Unsubscribe", new { PerId = ViewData["LoggedUser"], ProId = Model.Problem.Id })%>
    <% } %>
</asp:Content>
