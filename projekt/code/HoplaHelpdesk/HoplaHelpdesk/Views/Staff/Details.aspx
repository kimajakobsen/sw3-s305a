<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemDetailsCommentListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>
        <legend><%: Model.Problem.Title %></legend>
        <p>
            <%: Html.ActionLink("Edit", "Edit", new { id=Model.Problem.Id }) %> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>

        <% Html.RenderPartial("ProblemDetails", Model.Problem); %>
        <br />

        <h2>Comments</h2>
        
        <% Html.RenderPartial("CommentList", Model.Comments); %>

        <h2>Add Comment:</h2>

        <% Html.RenderPartial("EditorTemplates/CommentCreate", Model); %>

        
        <p> 
            <input type="submit" value="Save" />  
        </p>  

    </fieldset>
    


</asp:Content>
