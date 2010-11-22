<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HoplaHelpdesk.Models.Category>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CategorizeNewProblem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>CategorizeNewProblem</h2>

   
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

    


    <% foreach (var item in Model) { %>
    
      
              <h2> <%: item.Title %></h2>
          
                <table>
                 <% foreach (var tag in item.Tags)
                    { %>
                <tr>
                <td>
                <%: tag.Title%>
                
                </td>
                <td>
                    <%: Html.CheckBoxFor(tag => tag.) %>
                </td>
                
                
                </tr>
                 <% } %>
                </table>

    
    <% } %>

  
                <input type="submit" value="Create" />
          

    <% } %>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

