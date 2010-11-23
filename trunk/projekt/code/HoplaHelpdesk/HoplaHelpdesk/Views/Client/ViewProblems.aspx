<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HoplaHelpdesk.Models.Problem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewProblems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewProblems</h2>

  
  
        <% Html.RenderPartial("ProblemList", Model); %>
      
    
   

    <p>
        <%: Html.ActionLink("Create New", "CategorizeNewProblem") %>
    </p>

</asp:Content>

