<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

    <table class="problemlist" width="90%">
            <tr>
                <th width="20%">Title</th>
                <th width="20%">Deadline</th>
                <th width="10%">Priority</th>
                <th width="10%">ETC</th>
                <th width="40%">Description</th>
            </tr>
    <% foreach (var item in Model.Problems) { %>        
            <tr>
                <td>
                    <%:  Html.ActionLink(item.Title, "Details", new { item.Id })%>
                </td>
                <td>
                <% if (item.IsDeadlineApproved == true)
                   { %>
                Approved:
                <% }
                   else
                   { %>
                   Not approved:
                <% } %>
                <br />
                <%: item.Deadline %></td>
                <td><%: item.Priority %></td>
                <td><% if (item.Eta != null && item.Eta > DateTime.Now.Add(new TimeSpan(0, 0, 10, 0)))
                                      {%><%: String.Format("{0:g}", item.Eta)%>
                                      <%
                                      }
                                      else
                                      {%>
                              
                                        N/A
                                     
                                      <% 
                                      }
                                      %></td>
                <td><%: item.Description %></td>
            </tr>
    <% } %>
    </table>




