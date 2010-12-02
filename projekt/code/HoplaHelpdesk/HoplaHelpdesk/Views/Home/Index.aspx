<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    HoplaHelpDesk
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <%
    if (Request.IsAuthenticated) {
%>
<p>
        Welcome <b><%: Page.User.Identity.Name %></b>
        </p>
        <p>The functions provided to you are found in the bar above</p>
<%
    }
    else {
%> 
<p>
         You are not logged on right now. If you have a user, you can login <%: Html.ActionLink("here", "LogOn", "Account") %> or at top right corner.
         </p>
         <p>If you do not have a user, you can add one <%: Html.ActionLink("here", "Register", "Account") %>.</p>
<%
    }
%>

</asp:Content>
