<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.Models.Department>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%  %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Model.DepartmentName %></h2>
    <%: Model.Description %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
            <table border="1" class="ContentContainer" width="100%"> 
                <th align="left">Staff members</th>
                <th align="left">Categoryes</th>
                <tr>
                       
                    <td valign="top"  width="45%">
                    <% Html.RenderPartial("DepartmentStaffList", Model.Persons);  %> 
                    <%: Html.ActionLink("Add staff", "Details", "Person", new {PrevDepartment = Model.Id}, null)%>  
                    </td>

                    
                    <td valign="top" width="45%">
                    <% Html.RenderPartial("DepartmentCategoryList", Model.Categories);  %>
                    <%: Html.ActionLink("Create New Category", "Create", "Category", new { id = Model.Id}, null)%>
                    </td> 
                </tr>  
            </table>
        

    <% } %>


</asp:Content>

