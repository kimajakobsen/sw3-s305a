<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CategoryWithListViewModel>" %>

 
    <%: Html.ValidationSummary(true) %>

    <%: Html.HiddenFor(x => x.Name)  %>
    <%: Html.HiddenFor(x => x.Id)  %>
    <%: Html.HiddenFor(x => x.Department)  %>

  <% if (!Model.Hidden)
              { %>
              
    <%: Html.HiddenFor(x => x.DepartmentHolder)  %>
                <h2> <%: Model.Name %></h2>
         
        <% for (int i = 0; i < Model.TagList.Count; i++)
           { %>
         
           <%: Html.EditorFor(x => x.TagList[i], "TagSelectEditor") %>
           <% if(i+1 < Model.TagList.Count) 
              {%>
              ||
              <%} %>

        <%  } %>
<% }
     else
     { %>

     <% for (int i = 0; i < Model.TagList.Count; i++)
           { %>       
           <%: Html.EditorFor(x => x.TagList[i], "TagSelectEditor") %>
        <%  } %>
    <% } %>

 


