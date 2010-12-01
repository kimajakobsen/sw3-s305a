﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.SimilairProblemListViewModel>" %>
    <table class="problemlist" width="90%">
            <tr>
                <th width="10%">Deadline</th>
                <th width="10%">ETA</th>
                <th width="80%">Titel and description</th>
            </tr>
    <% foreach (var item in Model.Problems) { %>        
            <tr>
                <td><% if (item.IsDeadlineApproved == true) { %>  <%: String.Format("{0:g}", item.Deadline) %>  <% } %></td>
                <td><%: String.Format("{0:g}", item.Eta) %></td>
                <td><%:  Html.ActionLink(item.Title, "Details", new { item.Id })%>:<br /><br /><%: item.Description %></td>
            </tr>
    <% } %>
    </table>

