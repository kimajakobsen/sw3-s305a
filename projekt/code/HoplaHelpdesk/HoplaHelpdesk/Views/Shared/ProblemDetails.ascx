﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Problem>" %>

<!-- Dette er kun til staff -->

        <div class="display-label">Description</div>
        <div class="display-field"><%: Model.Description %></div>
        
        <div class="display-label">Added_date</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Added_date) %></div>

        <div class="display-label">Assigned staff</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.AssignedTo.Name) %></div>

        <div class="display-label">ETA</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Eta) %></div>
        
        <% if (!(Model.IsDeadlineApproved == null))
           { %>
            <div class="display-label">Deadline</div>
            <div class="display-field6"><%: String.Format("{0:g}", Model.Deadline) %></div>
        <% } %>
        <% else 
           { %>
            <div class="display-label">Deadline</div>
            <div class="display-field"><%: String.Format("{0:g}", "Deadline not approved") %></div>
        <% } %>

        <% if (!(Model.SolvedAtTime == null))
           { %>
                <div class="display-label">SolvedAtTime</div>
                <div class="display-field"><%: String.Format("{0:g}", Model.SolvedAtTime)%></div>
        <% } %>
        <% else 
           { %>
            <div class="display-label">SolvedAtTime</div>
            <div class="display-field"><%: String.Format("{0:g}", "Unsolved")%></div>
        <% } %>

        
        <% if (Model.Tags == null || Model.Tags.Count == 0)
           { %>
                <div class="display-label">Tags</div>
                <div class="display-field">No tags</div>
        <% } %>
        <% else 
           { %>
            <div class="display-label">SolvedAtTime</div>
            <div class="display-field"><%: Html.CatTagDisplay(Model.Tags) %>  </div>
        <% } %>
