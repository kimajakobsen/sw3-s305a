<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.SuccesReassignViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Succes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Succes</h2>
    <p>Problem has been succesfully rassigned from <strong><%:Model.From.Name %></strong> to <strong><%: Model.Problem.AssignedTo.Name %></strong></p>
</asp:Content>
