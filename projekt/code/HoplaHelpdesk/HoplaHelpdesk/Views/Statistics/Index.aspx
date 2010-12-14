<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.StatisticViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Statistics
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Statistics</h2>
        <% foreach(var department in Model.Departments){ %>
            <fieldset>
                <legend>
                    <%: department.Name %>
                </legend>
            <% if (department.Persons != null && department.Persons.Count != 0)
               { %>
            <% Html.RenderPartial("StatPersonList", department.Persons); %><br/>
            
            <p> 
            Average time to solve for all problems in the <%: department.Name%>: <%: department.AverageTimePerProblem()%> <br />
            Average time to solve during the past 7 days: <%: department.AverageTimePerProblemLastWeek()%> </p>
            <% }
               else
               { %>
               <p>No staff members employed in this department.</p>
            <% } %>
            </fieldset>
    <% } %>
   
    <p>
    Average time to solve for all problems in the system: <%: Model.AverageAllTime %> <br />
    Average time to solve during the past 7 days: <%: Model.AverageLastWeek %>
    </p>
</asp:Content>
