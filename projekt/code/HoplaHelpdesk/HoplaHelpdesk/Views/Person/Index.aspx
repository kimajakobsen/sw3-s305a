<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.PersonListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Person Index</h2>

     <% Html.RenderPartial("PersonList", Model.Persons); %>
    
    <%: Html.ActionLink("Create", "Create") %>

</asp:Content>

