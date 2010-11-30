<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.DepartmentListViewModel>"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Department Index</h2>

      <% Html.RenderPartial("DepartmentList", Model.Departments); %>
      
      <%: Html.ActionLink("Create", "Create"); %>

</asp:Content>
