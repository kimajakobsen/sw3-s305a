<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ProblemDetailsCommentListViewModel>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
            
            <%: Html.TextBoxFor(model => model.comment.description) %>
            <%: Html.HiddenFor(model => model.approveDeadline) %>
            <%: Html.HiddenFor(model => model.reassignability) %>
            <p>
                <input type="submit" value="Create Comment" />
            </p>       

    <% } %>


