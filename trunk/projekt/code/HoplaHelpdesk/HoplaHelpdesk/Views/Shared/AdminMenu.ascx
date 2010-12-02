<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

        <li><%: Html.ActionLink("Manage Departments", "Index", "Department")%></li>
        <li><%: Html.ActionLink("Manage People", "Index","person")%></li>
        <li><%: Html.ActionLink("Statistics","index", "Statistics")%></li>