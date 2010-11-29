<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemDetailsCommentListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>
        <legend><%: Model.Problem.Title %></legend>

        <% Html.RenderPartial("ProblemDetails", Model.Problem); %>
        <br />
        <h2>Solutions:</h2>
        
        <%: Html.ActionLink("Write new solution", "AddSolution", new { id= Model.Problem.Id })%>
        <%: Html.ActionLink("Attach solution from database", "ListSolutions", new { id= Model.Problem.Id })%>

        <% Html.RenderPartial("SolutionList", Model.Solutionlistviewmodel); %>
        <br />
        <h2>Comments:</h2>
        
        <% Html.RenderPartial("CommentList", Model.Commentlistviewmodel); %>

        <h2>Add Comment:</h2>

        <% Html.RenderPartial("EditorTemplates/CommentCreate", Model.comment); %>

        <%: Html.ActionLink("Reassign", "Index", "ReassignProblem", new { id=Model.Problem.Id }, null)%>
        <!--<p> 
            <input type="submit" value="Save" />  
        </p>  -->

    </fieldset>
    


</asp:Content>
