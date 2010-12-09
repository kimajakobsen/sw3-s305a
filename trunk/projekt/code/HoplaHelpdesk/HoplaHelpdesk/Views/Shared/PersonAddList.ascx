<%@ Control Language="C#"   
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

    <table class="problemlist" width="90%">
        <tr>
            <th>Action</th>
            <th>
                Name
            </th>
            <th>
                Email
            </th>
            <th>
            Department Name
        </th>
        <th>
            Workload
        </th>
        <% if (Model.Count() != 0 && Model.ToList()[0].Roles != null)
           {
               foreach (var item in Model.ToList()[0].Roles)
               {%>
                    <th>
                        <%: item.Name %>
                    </th>
        <%      }
           } %>

        </tr>

    <% foreach (var item in Model)
       { %>
        <% if (item.IsStaff())
           {%>
                <tr>
                    <td>
                        
                        <%: Html.ActionLink("Add", "ChangeDepartment", new { DepId = ViewData["homeDepartment"], PerId = item.Id })%>
                    </td>
                    <td>
                        <%: item.Name%>
                    </td>
                    <td>
                        <%: item.Email%>
                    </td>
                    <td><% if (item.Department != null)
                           { %>
                        <%: item.Department.Name%>
                        <% } %>
                    </td>
                    <td>
                        <%: item.Workload %>
                    </td>
                    <% if (item.Roles != null)
           {
               foreach (var role in item.Roles)
               {%>

                    <td>
                        <% if(role.Selected)
                           {%>
                           x
                           <% } %>
           
                    </td>
        <%      }
           } %>
                    
                </tr>
    
            <% } %>
            <%} %>

       </table>





