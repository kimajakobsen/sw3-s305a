<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CategoryWithListViewModel>" %>
<h2> <%: Model.Name %></h2>
 
        <%: Html.ValidationSummary(true) %>
     
        <% for (int i = 0; i < Model.TagList.Count; i++)
           { %>
         
           <%: Html.EditorFor(x => x.TagList[i], "TagSelectEditor") %>
           <% if(i+1 < Model.TagList.Count) 
              {%>
              ||
              <%} %>

             <%: Html.HiddenFor(x => x.Name)  %>

        <%  } %>
      

 


