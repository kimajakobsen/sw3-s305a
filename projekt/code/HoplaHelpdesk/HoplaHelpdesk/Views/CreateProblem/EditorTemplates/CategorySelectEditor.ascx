﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HoplaHelpdesk.Models.Category>" %>
<h2> <%: Model.Title %></h2>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <% for (int i = 0; i < Model.Tags.Count; i++)
           { %>

           <%: Html.EditorFor(x => x.Tags.ElementAt(i), "TagSelectEditor") %>



        <%  } %>
        <fieldset>
            <legend>Fields</legend>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>


