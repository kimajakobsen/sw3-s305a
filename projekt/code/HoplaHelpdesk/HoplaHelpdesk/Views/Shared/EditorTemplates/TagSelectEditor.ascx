<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Tag>" %>
<span class="editor-label">
        <%: Model.Name %>
        </span>
      <%: Html.CheckBoxFor(x => x.IsSelected)%>
      <%: Html.HiddenFor(x => x.Id) %>
    <%: Html.HiddenFor(x => x.Name) %>
