<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DateTime?>" %>  
  
<%string name = ViewData.TemplateInfo.HtmlFieldPrefix;%>  
<%string id = name.Replace(".", "_");%>  
<div class="editor-label">  
    <%= Html.LabelFor(model => model) %>  
</div>  
<div class="editor-field">  
    <%= Html.TextBoxFor(model => model) %>  
    <%= Html.ValidationMessageFor(model => model) %>  
</div>  
  
<script type="text/javascript">
    $(document).ready(function () {

        $("#<%=id%>").datepicker({
            showOn: 'both',
            dateFormat: 'dd M yy',
            changeMonth: true,
            changeYear: true
        });
    });  
</script>  