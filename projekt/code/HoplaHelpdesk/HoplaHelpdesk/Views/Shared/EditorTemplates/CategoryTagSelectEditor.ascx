<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CategoryTagSelectionViewModel>" %>
<p> John</p>
    <% for(int i = 0; i < Model.Categories.Count; i++)
           { %>  
         <%: Html.EditorFor(x => x.Categories[i], "CategorySelectEditor") %>
         <% }
          %>
