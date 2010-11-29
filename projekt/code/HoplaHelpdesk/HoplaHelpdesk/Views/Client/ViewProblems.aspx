<%@ Page Title="Problem Search" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.SearchViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Problem Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script> 
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script> 
    <script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script> 

    <h2>Problem Search</h2>
    
    <% Html.EnableClientValidation(); %> 
        <% using (Html.BeginForm()) {%>
        <fieldset>
            <legend>Search</legend>
            <table>
                <tr>
                    <th>
                    
                        <div class="editor-field">
                            <%: Html.EditorFor(model => model.CatTag,"CategoryTagSelectEditor") %>
                        </div>
                        
                    </th>

                    <th>
                        
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.OnlySubscriber) %>
                        </div>
                        <%: Html.CheckBoxFor(x => x.OnlySubscriber)%>
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.OnlyUnsolvedProblems) %>
                        </div>
                        <%: Html.CheckBoxFor(x => x.OnlyUnsolvedProblems)%>
                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.OnlySolvedProblems) %>
                        </div>
                        <%: Html.CheckBoxFor(x => x.OnlySolvedProblems)%>

                        <div class="editor-label">
                            <%: Html.LabelFor(model => model.MinimumNumberOfProblems) %>
                        </div>
                        <div class="editor-field">
                            <%: Html.TextBoxFor(model => model.MinimumNumberOfProblems)%>
            
                            <%: Html.ValidationMessageFor(model => model.MinimumNumberOfProblems)%>
                        </div>


                        <%: Html.HiddenFor(x => x.Subscriber) %>
                        <%: Html.HiddenFor(x => x.ProblemList) %>
                    </th>
                </tr>
            </table>
            

            <p>
                <input type="submit" value="Search" />
            </p>
        </fieldset>

    <% } %>

    
    <fieldset>
        <legend>Result</legend>
    <% if (Model != null && Model.ProblemList != null && Model.ProblemList.Problems != null && Model.ProblemList.Problems.Count != 0)
       { %>
    
        <p>There was found <%: Model.ProblemList.Problems.Count %> problems:</p>
    
        <% Html.RenderPartial("ProblemList", Model.ProblemList); %>
    <% }
       else
       { %>     
       <%if(ViewData["Message"] != null && ((string)ViewData["Message"]).Length != 0) 
         {%>
         <div>
            <%: ViewData["Message"] %>
         </div>
       <%}
         else
         { %>
          <p class="error">No problems where found</p>
            
    <% }
       } %>
    </fieldset> 

</asp:Content>

