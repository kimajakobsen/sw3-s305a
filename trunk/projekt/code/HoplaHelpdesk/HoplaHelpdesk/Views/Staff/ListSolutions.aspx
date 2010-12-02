<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.AttachSolutionViewModel>"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListSolution
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script> 
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script> 
    <script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script> 

    <h2><%: ViewData["Header"] %></h2>
    
    <% Html.EnableClientValidation(); %> 
        <% using (Html.BeginForm()) {%>
        <fieldset>
            <legend>Search</legend>
                        <div class="editor-field">
                            <%: Html.EditorFor(model => model.Search.CatTag,"CategoryTagSelectEditor") %>
                        </div>
                        <%: Html.HiddenFor(x => x.Search.MinimumNumberOfProblems)%>
                        <%: Html.HiddenFor(x => x.Search.OnlyUnsolvedProblems)%>
                        <%: Html.HiddenFor(x => x.Search.OnlySubscriber)%>
                        <%: Html.HiddenFor(x => x.Search.OnlySolvedProblems)%>
                        <%: Html.HiddenFor(x => x.Search.Subscriber)%>
                        <%: Html.HiddenFor(x => x.Search.ProblemList)%>
            </table>
            

            <p>
                <input type="submit" value="Search" />
            </p>
        </fieldset>

    <% } %>

    
    <fieldset>
        <legend>Result</legend>
    <% if (Model != null && Model.Search.ProblemList != null && Model.Search.ProblemList.Problems != null && Model.Search.ProblemList.Problems.Count != 0)
       { %>
    
        <p>There was found <%: Model.Search.ProblemList.Problems.Count%> problems:</p>
    
        <% Html.RenderPartial("ProblemClientList", Model.Search.ProblemList); %>
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

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

