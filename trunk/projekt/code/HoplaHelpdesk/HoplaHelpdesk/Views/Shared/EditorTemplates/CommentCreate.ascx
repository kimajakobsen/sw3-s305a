<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ProblemDetailsCommentListViewModel>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
            <%: Html.TextBoxFor(model => model.comment.description) %>

            <p>
                <input type="submit" value="Create Comment" />
            </p>       

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>


