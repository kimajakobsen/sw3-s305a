<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.CategoryTagSelectionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Categorize New Problem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Categorize New Problem</h2>

    <% using (Html.BeginForm()) {%>
    <fieldset>
            <legend>Categorization</legend>
        <div class="editor-field">
        <%: Html.EditorForModel("CategoryTagSelectEditor") %>
        </div>
            <p>
                <input type="submit" value="Search for this kind of problems" />
            </p>
     </fieldset>

    <% } %>

</asp:Content>

