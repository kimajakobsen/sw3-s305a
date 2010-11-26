<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewProblems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Problem Search</h2>
    
        <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Search</legend>
            <div class="editor-field">
                <%: Html.EditorFor("CategoryTagSelectEditor") %>
            </div>
            <p>
                <input type="submit" value="Search" />
            </p>
        </fieldset>

    <% } %>
    
    <% if (Model != null && Model.Problems != null && Model.Problems.Count != 0)
       { %>
    <fieldset>
        <legend>Result</legend>
    
        <% Html.RenderPartial("ProblemList", Model); %>
    </fieldset> 
    <% } %> 
    
   

    <p>
        <%: Html.ActionLink("Create New", "Index","CreateProblem") %>
    </p>

</asp:Content>

