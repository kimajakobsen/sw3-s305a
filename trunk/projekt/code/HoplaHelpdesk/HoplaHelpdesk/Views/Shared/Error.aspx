<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Error
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Error</h2>
    <% if (ViewData["Error"] == null)
       {
       %>
       <p class="error">Some Error occured while processing your request!</p>

       <% }
       else
       { %>
       <p class="error"><%: ViewData["Error"] %></p>

       <%
       } %>
        <%if (ViewData["Back"] == null || ViewData["Back"] == "")
          {
              ViewData["Back"] = "Back";
          } %>

         <% if (ViewData["View"] != null)
       {
       %>
            <% if (ViewData["Id"] != null)
               {%>
                <%: Html.ActionLink((string)ViewData["Back"], (string)ViewData["View"], new { id = ViewData["Id"] })%>
               <%}
               else
               { %>
      <%: Html.ActionLink((string)ViewData["Back"], (string)ViewData["View"]) %>
       <% } %>
       <% } %>
       

</asp:Content>
