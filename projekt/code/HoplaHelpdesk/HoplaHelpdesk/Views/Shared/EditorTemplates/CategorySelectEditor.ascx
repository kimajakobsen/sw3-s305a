<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Category>" %>
<h2> <%: Model.Title %></h2>
 
        <%: Html.ValidationSummary(true) %>
     
        <% for (int i = 0; i < Model.Tags.Count; i++)
           { %>
         
           <%: Html.EditorFor(x => x.Tags[i], "TagSelectEditor") %>

             <%: Html.HiddenFor(x => x.Title)  %>

        <%  } %>
      

 


