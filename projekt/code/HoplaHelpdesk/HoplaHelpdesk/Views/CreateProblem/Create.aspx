<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemCatTagWithSelectionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Problem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Problem</h2>

    <% using (Html.BeginForm()) {%>
        

            <fieldset>
            
            <legend>Description</legend>

            <%: Html.EditorFor(x => x.Problem, "ProblemCreate") %>
            </fieldset>
           
            <fieldset>

                <legend>Categorization</legend>
                <%: Html.EditorFor(model => model.CatTag,"CategoryTagSelectEditor") %>
           
                  <% Model.Person.Name = Page.User.Identity.Name; %>
                  <%: Html.HiddenFor(model => model.Person.Name) %>
            </fieldset>
            <p>
                <input type="submit" value="Create" />
            </p>
    <% } %>
    
    <div>
        <%: Html.ActionLink("Back to Categorization", "CategorizeNewProblem") %>
    </div>

</asp:Content>

