<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Person>" %>

<table class="ContentContainer" cellspacing="0" width="100%">
    <tr>
        <td>
            
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

            <% if(Model.IsStaff()) 
               {%>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.DepartmentId)%> 
                </div>
                <div class="editor-field">
                    <%: Html.DropDownList("DepartmentId", new SelectList(ViewData["Departments"] as IEnumerable,
                        "Id", "DepartmentName", Model.DepartmentId))%>
                </div>
            <%} %>
        </td>
        <td>
            <% for(int i = 0 ; i< Model.Roles.Count ; i++)
            { %>
                <div class="editor-label">
                    <%: Model.Roles[i].Name %>
                </div>
                <div class="editor-field">
                    <%: Html.CheckBoxFor(x => x.Roles[i].Selected)%>
                </div>
                <%: Html.HiddenFor(x=>x.Roles[i].Name) %>
            <% } %>
        </td>
    </tr>
</table>