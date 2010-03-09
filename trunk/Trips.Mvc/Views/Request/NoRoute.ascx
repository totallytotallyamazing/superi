<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Helpers" %>
<div class="calc">
    <div class="raschetBox">
        <div class="raschetBoxLeft">
        </div>
        <div class="raschetBoxRight">
        </div>
        <div class="raschetBoxContent" style="padding-top:5px; height:43px;">
            <%= Html.ResourceString("CalculatedIndividually") %>
        </div>
    </div>
</div>
