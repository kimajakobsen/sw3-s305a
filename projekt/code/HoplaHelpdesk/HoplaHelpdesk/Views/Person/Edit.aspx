<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.EditPersonViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Person
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Person</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Person</legend>
            
            <%: Html.EditorFor(x => x.Person, new { Departments = Model.AllDepartments}) %>

            <% foreach (var role in Model.Roles)
               { %>
                <div class="editor-label">
                    <%: Html.LabelFor(model => role.Name)%> 
                </div>
                <div class="editor-field">
                    <%: Html.DropDownList("Name", new SelectList(Model.Roles as IEnumerable,
                        "this", "Name", Model.Role))%>
                </div>
             <% } %>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

