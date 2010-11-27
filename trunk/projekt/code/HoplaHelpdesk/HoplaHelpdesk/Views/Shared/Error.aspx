<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Error
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Error</h2>
    <% if (ViewData["Error"] == null)
       {
       %>
       <p>Some Error occured</p>

       <% }
       else
       { %>
       <%:ViewData["Error"] %>

       <%
       } %>

         <% if (ViewData["View"] != null)
       {
       %>
      <%: Html.ActionLink("Back", ViewData["View"]) %>
       <% }
       

</asp:Content>
