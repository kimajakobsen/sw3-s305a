<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.Models.Problem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddProblem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AddProblem</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            <div class="editor-label">
            <%: Html.TextBoxFor(model => model.Title) %>
            
            </div>
             <div class="editor-label">
            <%: Html.TextAreaFor(model => model.Description) %>
            
            </div>
 
            <p>

                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

