<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.SimilairProblemListViewModel>" %>
    <table class="problemlist" width="90%">
            <tr>
                <th width="10%">No. of matching tags</th>
                <th width="10%">Deadline</th>
                <th width="10%">ETC</th>
                <th width="70%">Titel and description</th>
            </tr>
    <% foreach (var item in Model.Problems) { %>        
            <tr>
                <td>
                <% if (ViewData["AllTags"] != null || (ViewData["AllTags"] is List<HoplaHelpdesk.Models.Tag>))
                   {%>
                        <%: item.NumOfMatchingTags((List<HoplaHelpdesk.Models.Tag>)ViewData["AllTags"])%>
                 <%}
                   else
                   {%>
                   N/A
                   <%} %>
                </td>
                <td><% if (item.IsDeadlineApproved == true) { %>  <%: String.Format("{0:g}", item.Deadline) %>  <% } %></td>
                <td>
                <%if (item.Eta > DateTime.Now.Add(new TimeSpan(1, 0, 0)))
                  {%>
                    <%: String.Format("{0:g}", item.Eta)%>
                  <%
                  }
                  else
                  {
                  %>N/A<%    
                  } %>
                </td>
                <td><%:  Html.ActionLink(item.Title, "Details", new { item.Id })%>:<br /><br /><%: item.Description %></td>
            </tr>
    <% } %>
    </table>

