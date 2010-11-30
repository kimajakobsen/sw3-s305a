<%@ Control Language="C#"   
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HoplaHelpdesk.Models.Person>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Name
            </th>
            <th>
                Email
            </th>
            <th>
                Client
            </th>
            <th>
                Staff
            </th>
            <th>
                Admin
            </th>
            <th>
                Department name
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <!-- lav en if statement der tjekker om personen kan tilføjes til en department -->
                <%: Html.ActionLink("Add", "ChangeDepartment", new { DepId = ViewData["homeDepartment"], PerId = item.Id}) %> |
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
            <% foreach (var role in item.Roles)
               {%>
            <%    if (role.Selected && role.Name.ToString() == "Client")
                  {%>
                    x
                <% } %>
            <% } %>
            </td>
            <td>
            <% foreach (var role in item.Roles)
               {%>
            <%    if (role.Selected && role.Name.ToString() == "Staff")
                  {%>
                    x
                <% } %>
            <% } %>
            </td>
            <td>
            <% foreach (var role in item.Roles)
               {%>
            <%    if (role.Selected && role.Name.ToString() == "Admin")
                  {%>
                    x
                <% } %>
            <% } %>
            </td>
            <td>
                <%: item.DepartmentId %>
            </td>
        </tr>
    
    <% } %>

    </table>




