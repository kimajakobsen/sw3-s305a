<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Tag>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <%: Model.Title %>
      <%: Html.CheckBoxFor(x => x.IsSelected)%>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>


