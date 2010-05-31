<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<div class="articleDetails">
        <%= Html.Hidden("id_" + Model.ToString()) %>
        <table>
            <tr>
                <td valign="middle" align="right">���������:</td>
                <td align="left">
                    <%= Html.TextArea("title_" + Model.ToString(), new { cols = "40", rows = "2" })%>
                </td>
            </tr>
            <tr>
                <td valign="middle" align="right">������������:</td>
                <td align="left">
                    <%= Html.TextArea("subTitle_" + Model.ToString(), new { cols = "40", rows = "2" })%>
                </td>
            </tr>
            <tr>
                <td valign="middle" align="right">������:</td>
                <td align="left">
                    <%= Html.TextArea("description_" + Model.ToString(), (string)ViewData["description_" + Model.ToString()],  new { style="width:300px;" })%>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%= Html.TextArea("text_" + Model.ToString())%>
                    <%= Ajax.CkEditor("text_" + Model.ToString(), true, null)%>                
                </td>
            </tr>
        </table>
</div>