<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Problem>" %>

<div class="editor-label">
            <%: Html.TextBoxFor(model => model.Title) %>
            
            </div>
             <div class="editor-label">
            <%: Html.TextAreaFor(model => model.Description) %>
            
            </div>