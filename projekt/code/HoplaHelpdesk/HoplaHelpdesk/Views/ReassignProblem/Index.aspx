<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HoplaHelpdesk.Models.Department>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Assign To</h2>

   

    <% foreach (var item in Model) { %>
    
             <h3>
                <%: item.DepartmentName %>
          </h3> <%: Html.ActionLink("Assign To department", "Assign", new { id=0,dept=item.Id }) %> <br /><br />
            
          
           
           
   
            <% Html.RenderPartial("StaffList", item.Persons); %>
       
    <% } %>

   

</asp:Content>

