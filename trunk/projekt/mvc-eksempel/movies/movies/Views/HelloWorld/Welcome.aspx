<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Movies.Controllers.HelloWorldController+WelcomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Welcome
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    int counter = 0;
    <h2>Welcome</h2>

<% for(int i=0;i<Model.Height;i++) { %>
       <%h3><%: Model.Message %></h3>
<% } %>

</asp:Content>
