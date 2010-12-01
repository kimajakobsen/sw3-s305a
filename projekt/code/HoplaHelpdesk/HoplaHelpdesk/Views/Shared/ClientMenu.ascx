<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

        <li><%: Html.ActionLink("Commit Problem", "CategorizeNewProblem", "CreateProblem") %></li>
        <li><%: Html.ActionLink("My Problems", "ViewProblems", "Client", new { id = -1 }, null)%></li>
        <li><%: Html.ActionLink("Search for Problems", "ViewProblems", "Client", new { id = 0},null)%></li>