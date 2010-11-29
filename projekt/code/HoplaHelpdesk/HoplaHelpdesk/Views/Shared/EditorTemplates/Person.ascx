<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Person>" %>

<div class="editor-label">
    <%: Html.LabelFor(model => model.Id) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.Id)%>
    <%: Html.ValidationMessageFor(model => model.Id)%>
</div>
            
<div class="editor-label">
    <%: Html.LabelFor(model => model.Name)%>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.Name)%>
    <%: Html.ValidationMessageFor(model => model.Name)%>
</div>
            
<div class="editor-label">
    <%: Html.LabelFor(model => model.Email)%>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.Email)%>
    <%: Html.ValidationMessageFor(model => model.Email)%>
</div>
            
<div class="editor-label">
    <%: Html.LabelFor(model => model.DepartmentId)%> 
</div>
<div class="editor-field">
    <%: Html.DropDownList("DepartmentId", new SelectList(ViewData["Departments"] as IEnumerable,
        "Id", "DepartmentName", Model.DepartmentId))%>
</div>