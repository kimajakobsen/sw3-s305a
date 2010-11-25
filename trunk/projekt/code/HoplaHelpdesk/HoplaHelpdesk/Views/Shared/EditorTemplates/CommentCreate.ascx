<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Comment>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.description) %>
                <%: Html.ValidationMessageFor(model => model.description) %>
            </div>          
            <p>
                <input type="submit" value="Add comment" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>


