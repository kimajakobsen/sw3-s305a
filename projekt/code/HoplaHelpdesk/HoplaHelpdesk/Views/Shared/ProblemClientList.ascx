<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

    <table class="problemlist" width="90%">
            <tr>
                <th width="20%">Title</th>
                <th width="10%">Deadline</th>
                <th width="10%">ETC</th>
                <th width="10%">Solved</th>
                <th width="50%">Description</th>
            </tr>
    <% foreach (var item in Model.Problems) { %>        
            <tr>
                <td><%:  Html.ActionLink(item.Title, "Details", new { item.Id })%></td>
                <% if (item.IsDeadlineApproved == true)
                   { %> <td><%: item.Deadline%></td> <% } %>
                <% else 
                   { %><td>Deadline not approved</td><% } %>
                
                <td>
                <% if (item.Eta > DateTime.Now.Add(new TimeSpan(1, 0, 0)))
                   { %>
                   <%: item.Eta%>
                   <%
                    }
                   else
                   {
                   %>N/A<%
                   }
                   %>
                </td> 
                
                <% if (!(item.SolvedAtTime == null))
                   
                   { %><td><%: item.SolvedAtTime%></td><% } %>
                <% else
                   { %><td>Unsolved</td><% } %>

                <td><%: item.Description %></td>
            </tr>
    <% } %>
    </table>




