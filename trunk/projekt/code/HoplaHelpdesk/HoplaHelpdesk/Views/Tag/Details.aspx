<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.Models.Tag>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
        <div class="display-label">Description</div>
        <div class="display-field"><%: Model.Description %></div>
        
        <div class="display-label">Priority</div>
        <div class="display-field"><%: Model.Priority %></div>
        
        <div class="display-label">Category_Id</div>
        <div class="display-field"><%: Model.Category_Id %></div>
        
        <div class="display-label">SolvedProblems</div>
        <div class="display-field"><%: Model.SolvedProblems %></div>
        
        <div class="display-label">TimeConsumed</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.TimeConsumed) %></div>
        
        <div class="display-label">AverageTimeSpent</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.AverageTimeSpent) %></div>
        
        <div class="display-label">Hidden</div>
        <div class="display-field"><%: Model.Hidden %></div>
        
        
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "Details", "Category", new{ id=Model.Category_Id },null)%>
    </p>

</asp:Content>

