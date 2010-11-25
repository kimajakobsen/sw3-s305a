<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Department>>" %>



    <% foreach (var item in Model) { %>
   <p>  
         <%: item.DepartmentName %>
   </p>
                
    <% } %>



<form name="myform" action="http://www.mydomain.com/myformhandler.cgi" method="POST">
<div>
<select name="DepartmentsDropDown">
<option value="Bread">Hot Bread</option>
</select>
</div>
</form>
   


