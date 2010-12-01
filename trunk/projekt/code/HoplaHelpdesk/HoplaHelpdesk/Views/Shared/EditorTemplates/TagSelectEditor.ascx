<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Tag>" %>
        <%: Model.Name %>
      <%: Html.CheckBoxFor(x => x.IsSelected)%>
      <%: Html.HiddenFor(x => x.Id) %>
    <%: Html.HiddenFor(x => x.Name) %> |
