<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Tag>" %>
<% if(!Model.Hidden) 
   {%>
<span class="editor-label">
        <%: Model.Name %>
        </span>
        <%: Html.CheckBoxFor(x => x.IsSelected)%>
        <%} 
   else
   {%>
   <%: Html.HiddenFor(x => x.IsSelected)%>
   <%} %>
      
      <%: Html.HiddenFor(x => x.Id) %>
    <%: Html.HiddenFor(x => x.Name) %>
    <%: Html.HiddenFor(x => x.Hidden) %>
