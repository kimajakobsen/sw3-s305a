<%@ Control Language="C#"   Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

<table class="problemlist" width="90%">
    <tr>
        <th>Actions</th>
        <th>
            Id
        </th>
        <th>
            Name
        </th>
        <th>
            E-mail
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
   {%>
    <tr>
        <td>
            <%: Html.ActionLink("Edit", "Edit", "Person", new { id = item.Id }, null)%> |
            <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%> |
            <%: Html.ActionLink("Reset password","PassMail",new { item.Id }) %>
        </td>
        <td>
            <%: item.Id%>
        </td>
        <td>
            <%: item.Name%>
        </td>
        <td>
            <%: item.Email%>
        </td>
        <% if (item.IsStaff())
           { %>
        <td>
            <% if (item.Department != null)
               {%>       
            <%: item.Department.Name%>
            <%}
               else
               { %>
               Error
            <%} %>
        </td>
        <td>
            <%: item.GetWorkload()%>
        </td>
        <% }
           else
           {%>
            <td>N/A</td>
            <td>N/A</td>
            <%} %>
           <% if (item.Roles != null)
           {
               foreach (var role in item.Roles)
               {%>
               <!-- The following selects the person in item, finds his roles and selct the client role to make a checkbox -->
                    <td>
                        <% if(role.Selected)
                           {%>
                           x
                           <% } %>
                       <!-- 
                        <percent: Html.CheckBoxFor(x => x.FirstOrDefault(y => y.Id == item.Id).Roles.FirstOrDefault(z => z.Name == role.Name).Selected)%>
                        <percent: Html.HiddenFor(x => x.FirstOrDefault(y => y.Id == item.Id).Roles.FirstOrDefault(z => z.Name == role.Name).Name)%>
                        -->
                    </td>
        <%      }
           } %>

    </tr>
    
<% } %>

</table>