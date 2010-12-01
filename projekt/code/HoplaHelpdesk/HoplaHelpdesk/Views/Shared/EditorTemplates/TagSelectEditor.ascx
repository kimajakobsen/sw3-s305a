<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Tag>" %>
<div class="editor-label">
        <%: Model.Name %>
        </div>
      <%: Html.CheckBoxFor(x => x.IsSelected)%>
      <%: Html.HiddenFor(x => x.Id) %>
    <%: Html.HiddenFor(x => x.Name) %> |
