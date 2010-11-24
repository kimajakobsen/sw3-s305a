<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.ProblemListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Similar Problems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Similar Problems</h2>

    
    <% using (Html.BeginForm("NoSufficeCreate", "CreateProblem")) {%>
        <%: Html.ValidationSummary(true) %>
        
        <%: Html.HiddenFor(x => x.SelectedCatTag) %>
          

    
    <% Html.RenderPartial("ProblemList", Model); %>
    
     <p>
       <input type="submit" value="No Problem Suffice" />
     </p>
    
    <% } %>


</asp:Content>
