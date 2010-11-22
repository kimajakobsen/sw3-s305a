<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Tag>" %>


        
        <%: Model.Title %>
      <%: Html.CheckBoxFor(x => x.IsSelected)%>
      <%: Html.HiddenFor(x => x.Id) %>
    <%: Html.HiddenFor(x => x.Title) %>

 

