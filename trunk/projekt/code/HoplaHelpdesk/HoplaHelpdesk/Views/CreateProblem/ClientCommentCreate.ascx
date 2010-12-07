<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ClientProblemDetailsViewModel>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>


        <%: Html.TextAreaFor(model => model.Comment.description) %>

        <p>
            <input type="submit" value="Submit comment" />
        </p>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>


