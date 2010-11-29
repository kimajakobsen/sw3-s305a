<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul>
        <li><%: Html.ActionLink("Administrate departments, categories and tags", "Index", "Department")%></li>
        <li><%: Html.ActionLink("Person Administrate", "Index","person")%></li>
    </ul>
    Add user to role.
 <form name="input" action="../Person/AddUserToRole" method="get">
Username: <input type="text" name="user" /><br />
Role:<input type="text" name="role" />
<input type="submit" value="Submit" />
</form>

Remove user from role.
 <form name="input" action="../Person/UnRole" method="get">
Username: <input type="text" name="user" /><br />
Role:<input type="text" name="role" />
<input type="submit" value="Submit" />
</form>

Check if user is staff
 <form name="input" action="../Person/IsStaff" method="get">
Username: <input type="text" name="user" />
<input type="submit" value="Submit" />
</form>

</asp:Content>
