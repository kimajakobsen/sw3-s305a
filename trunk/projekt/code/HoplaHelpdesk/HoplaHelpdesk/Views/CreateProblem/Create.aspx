<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemCatTagWithSelectionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Problem</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <fieldset>
            
            <legend>Description</legend>

            <%: Html.EditorFor(x => x.Problem, "ProblemCreate") %>
            </fieldset>
           
            <fieldset>

            <legend>Categorization</legend>

              <%: Html.EditorFor(model => model.CatTag,"CategoryTagSelectEditor") %>
              </fieldset>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

