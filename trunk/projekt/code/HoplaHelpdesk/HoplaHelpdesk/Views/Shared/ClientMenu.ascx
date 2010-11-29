<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

        <li><%: Html.ActionLink("Commit Problem", "CategorizeNewProblem", "CreateProblem") %></li>
        <li><%: Html.ActionLink("My problems", "ViewProblems", new { id = Model })%></li>
        <li><%: Html.ActionLink("Search for problems", "ViewProblems") %></li>