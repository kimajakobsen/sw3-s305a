<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HoplaHelpdesk.Models.Category>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CategorizeNewProblem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>CategorizeNewProblem</h2>

   

    <% foreach (var item in Model) { %>
    
      
              <h2> <%: item.Title %></h2>
          
                <table>
                 <% foreach (var tags in item.Tags)
                    { %>
                <tr>
                <td>
                <%: tags.Title%>
                
                </td>
                
                
                </tr>
                 <% } %>
                </table>

    
    <% } %>

  
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

