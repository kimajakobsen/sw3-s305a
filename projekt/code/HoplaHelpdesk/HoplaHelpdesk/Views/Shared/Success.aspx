﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Success
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Success</h2>
    <% if (ViewData["Success"] == null)
       {
       %>
       <p>The operation was successfully completed.</p>

       <% }
       else
       { %>
       <p><%: ViewData["Success"] %></p>

       <%
       } %>

         <% if (ViewData["View"] != null)
       {
       %>
      <%: Html.ActionLink("Back", (string)ViewData["View"]) %>
       <% } %>
       

</asp:Content>
