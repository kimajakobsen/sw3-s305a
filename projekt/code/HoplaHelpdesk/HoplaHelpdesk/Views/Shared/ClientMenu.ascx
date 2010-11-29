<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

        <li><%: Html.ActionLink("Commit Problem", "CategorizeNewProblem", "CreateProblem") %></li>
        <li><%: Html.ActionLink("My problems", "ViewProblems", "Client", new { id = Page.User.Identity.Name.ToString() }, null)%></li>
        <li><%: Html.ActionLink("Search for problems", "ViewProblems", "Client") %></li>