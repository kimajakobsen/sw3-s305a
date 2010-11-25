<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Problem>" %>

 
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
                <%: Html.TextBoxFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
           
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Deadline) %>
            </div>
            <div class="editor-field">
               
                <%: Html.TextBoxFor(model => model.Deadline, String.Format("{0:g}", Model.Deadline)) %>
                <%: Html.ValidationMessageFor(model => model.Deadline) %>
            </div>
            
            
   

  
