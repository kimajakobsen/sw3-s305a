<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Problem>" %>

<!-- Dette er kun til staff -->

        <div class="display-label">Description</div>
        <div class="display-field"><%: Model.Description %></div>
        
        <div class="display-label">Added date</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Added_date) %></div>

        <div class="display-label">Assigned staff member</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.AssignedTo.Name) %>  from  <%: Model.AssignedTo.Department.Name %> </div>

        <div class="display-label">ETC</div>
        <div class="display-field"><% if (Model.Eta > DateTime.Now.Add(new TimeSpan(0, 0, 10, 0)))
                                      {%><%: String.Format("{0:g}", Model.Eta)%>
                                      <%
                                      }
                                      else
                                      {%>
                              
                                        Unfortuntly, our system does not have enough data to predict when your problem will be solved.
                                     
                                      <% 
                                      }
                                      %></div>
        
        

        <div class="display-label">Deadline Approval</div>
        <div class="display-field">
            <% if (Model.IsDeadlineApproved.GetValueOrDefault())
               {%>
                     <%: String.Format("{0:g}", "Deadline approved")%>
               <%}
               else
               { %>
                     <%: String.Format("{0:g}", "Deadline not approved")%>
            <%} %>
        </div>

        <% if (Model.IsDeadlineApproved.GetValueOrDefault())
               {%>
        <div class="display-label">Deadline</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Deadline) %></div>
        <%} %>


        <% if (!(Model.SolvedAtTime == null))
           { %>
                <div class="display-label">Solved time</div>
                <div class="display-field"><%: String.Format("{0:g}", Model.SolvedAtTime)%></div>
        <% } %>
        <% else 
           { %>
            <div class="display-label">Solved time</div>
            <div class="display-field"><%: String.Format("{0:g}", "Unsolved")%></div>
        <% } %>

        
        <% if (Model.Tags == null || Model.Tags.Count == 0)
           { %>
                <div class="display-label">Tags</div>
                <div class="display-field">No tags</div>
        <% } %>
        <% else 
           { %>
            <div class="display-label">Categories and tags</div>
            <div class="display-field"><%: Html.CatTagDisplay(Model.Tags) %>  </div>
        <% } %>