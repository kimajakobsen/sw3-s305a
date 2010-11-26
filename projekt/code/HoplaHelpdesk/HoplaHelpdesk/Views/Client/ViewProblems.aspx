<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<HoplaHelpdesk.ViewModels.SearchViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewProblems
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Problem Search</h2>
    
        <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Search</legend>
            <table class="ContentContainer">
                <tr>
                    <th width="80%">
                    
                        <div class="editor-field">
                            <%: Html.EditorFor(model => model.CatTag,"CategoryTagSelectEditor") %>
                        </div>
                        <p>
                            <input type="submit" value="Search" />
                        </p>
                    </th>

                    <th width="20%">
                        <div class="editor-field">
                        
                        </div>
                        <p>Only your problems<br/></p>
                        <%: Html.CheckBoxFor(x => x.OnlySubscriber)%>
                        <p><br />Only unsolved problems<br/></p>
                        <%: Html.CheckBoxFor(x => x.OnlyUnsolvedProblems)%>
                    </th>
                </tr>
            </table>
        </fieldset>

    <% } %>
    
    <% if (Model != null && Model.ProblemList != null && Model.ProblemList.Problems != null && Model.ProblemList.Problems.Count != 0)
       { %>
    <fieldset>
        <legend>Result</legend>
    
        <% Html.RenderPartial("ProblemList", Model.ProblemList); %>
    </fieldset> 
    <% } %> 

</asp:Content>

