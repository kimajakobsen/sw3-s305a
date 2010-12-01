<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.Models.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Choose Department
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Choose Department</h2>

     <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DepartmentId)%> 
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(x => x.DepartmentId, new SelectList(ViewData["Departments"] as IEnumerable,
                    "Id", "DepartmentName", Model.DepartmentId))%>
            </div>
            
           
            
            <p>
                <input type="submit" value="Save" />
            </p>
    <% } %>

    <%: Html.ActionLink("Go Back", "BackToEdit", new{id = Model.Id}) %>

</asp:Content>
