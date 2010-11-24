<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Problem>" %>

               
            <%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

               
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
            
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Added_date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Added_date) %>
                <%: Html.ValidationMessageFor(model => model.Added_date) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Deadline) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Deadline) %>
                <%: Html.ValidationMessageFor(model => model.Deadline) %>
            </div>
          
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.IsDeadlineApproved) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.IsDeadlineApproved) %>
                <%: Html.ValidationMessageFor(model => model.IsDeadlineApproved) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AssignedTo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AssignedTo) %>
                <%: Html.ValidationMessageFor(model => model.AssignedTo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Reassignable) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Reassignable) %>
                <%: Html.ValidationMessageFor(model => model.Reassignable) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SolvedAtTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SolvedAtTime) %>
                <%: Html.ValidationMessageFor(model => model.SolvedAtTime) %>
            </div>
            
    




            
    

