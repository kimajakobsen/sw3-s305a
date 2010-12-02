<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CategoryWithListViewModel>" %>
<h2> <%: Model.Name %></h2>
 
        <%: Html.ValidationSummary(true) %>

         <%: Html.HiddenFor(x => x.Name)  %>
             <%: Html.HiddenFor(x => x.Id)  %>
             <%: Html.HiddenFor(x => x.Department)  %>
     <%: Html.HiddenFor(x => x.DepartmentHolder)  %>
        <% for (int i = 0; i < Model.TagList.Count; i++)
           { %>
         
           <%: Html.EditorFor(x => x.TagList[i], "TagSelectEditor") %>
           <% if(i+1 < Model.TagList.Count) 
              {%>
              ||
              <%} %>

            
              


        <%  } %>
      

 


