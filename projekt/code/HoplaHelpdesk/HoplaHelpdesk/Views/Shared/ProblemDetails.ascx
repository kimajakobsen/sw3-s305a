<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Problem>" %>


        <div class="display-label">Description</div>
        <div class="display-field"><%: Model.Description %></div>
        
        <div class="display-label">Added_date</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Added_date) %></div>
        
        <div class="display-label">Deadline</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Deadline) %></div>

        <div class="display-label">SolvedAtTime</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.SolvedAtTime) %></div>

