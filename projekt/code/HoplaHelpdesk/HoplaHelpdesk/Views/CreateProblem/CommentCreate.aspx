<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.ViewModels.ClientProblemDetailsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CommentCreate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
            <%: Html.TextBoxFor(model => model.Comment.description) %>

            <p>
                <input type="submit" value="Submit Comment" />
            </p>       

    <% } %>

</asp:Content>

