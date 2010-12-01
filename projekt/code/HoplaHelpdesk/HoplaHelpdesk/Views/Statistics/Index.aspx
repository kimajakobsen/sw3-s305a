<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.StatisticViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Person Statistic</h2>
    <% foreach(var department in Model.Departments){ %>
    <h3><%: department.Name %></h3>
    <% Html.RenderPartial("StatPersonList", department.Persons); %>
     <br /> 
    <p> Department in average: <%: department.AverageTimePerProblem() %>. In last week <%: department.AverageTimePerProblemLastWeek() %> </p>
    <% } %>
    <br />   <br />   <br />  
   
    <p>
    In total all staff solved a problem in average of <%: Model.AverageAllTime %>. 
    Last week in average were <%: Model.AverageLastWeek %>
    </p>
</asp:Content>
