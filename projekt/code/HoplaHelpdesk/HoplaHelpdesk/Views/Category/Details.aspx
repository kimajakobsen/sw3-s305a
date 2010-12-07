<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.Models.Category>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Category</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
        <div class="display-label">Description</div>
        <div class="display-field"><%: Model.Description %></div>
        
        <div class="display-label">Department</div>
        <div class="display-field"><%: Model.Department.DepartmentName %></div>

        <div class="display-label">Is Hidden</div>
        <div class="display-field"><%: Model.Hidden %></div>


        <% Html.RenderPartial("TagList", Model.Tags); %>
        <%: Html.ActionLink("Create new Tag", "Create", "Tag", new { id = Model.Id }, null)%>
    </fieldset>
    <p>
        <%: Html.ActionLink("Delete", "Delete",  new { id=Model.Id }) %> |
        <% if(Model.Hidden == false){
                %>
        <%: Html.ActionLink("Hide", "HideUnhide",  new { id=Model.Id,value=true }) %> |
        <% } else { %>
          <%: Html.ActionLink("Unhide", "HideUnhide", new { id = Model.Id, value=false })%> |
          <% } %>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %>
        <div>
        <%: Html.ActionLink("Back to List", "Edit", "Department", new {id=Model.Department_Id }, null) %>
    </div>
    </p>

</asp:Content>

