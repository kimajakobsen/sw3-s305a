<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemCatTagWithSelectionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CategorizeNewProblem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>CategorizeNewProblem</h2>

    <% using (Html.BeginForm()) {%>
  
        <div class="editor-field">
        <% Html.EditorFor(x => x.CatTag,"CategoryTagSelectEditor") %>
        </div>

        <fieldset>
            <legend>Fields</legend>
            
            <p>
                <input type="submit" value="Search for this kind of problems" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

