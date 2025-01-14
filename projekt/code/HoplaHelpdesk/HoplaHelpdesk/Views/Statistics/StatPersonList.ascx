﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>
    <table width="90%" class="Statistics">
        <tr>
            <th align="left">
                Id
            </th>
            <th align="left">
                Name
            </th>
            <th align="left">
                Workload
            </th>
            <th align="left">
                Per Problem
            </th>
             <th align="left">
                Past 7 Days
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Workload) %>
            </td>
            <td>
                <%: item.AverageTimePerProblem() %>
            </td>
            <td>
                <%: item.AverageTimePerProblemLastWeek() %>
            </td>
        </tr>
    
    <% } %>

    </table>

