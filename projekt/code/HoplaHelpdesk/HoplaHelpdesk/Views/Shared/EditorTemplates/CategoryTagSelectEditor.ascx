<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.CategoryTagSelectionViewModel>" %>
    <% for(int i = 0; i < Model.Categories.Count; i++)
           { %>  
           <% if (!(Model.Categories[i].Hidden))
              { %>
                <%: Html.EditorFor(x => x.Categories[i], "CategorySelectEditor")%>
            <% } %>
         <% } %>
