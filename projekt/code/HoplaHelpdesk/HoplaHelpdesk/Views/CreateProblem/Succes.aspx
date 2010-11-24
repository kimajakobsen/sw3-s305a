<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Succes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Succes</h2>

    <p>Your problem has been succesfully added!<br />
    <br />

    <%: Html.ActionLink("Return to Home", "Index", "Client")%>
    
    </p>


</asp:Content>
