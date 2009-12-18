<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditText
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <% using(Html.BeginForm()){ %>  
        <%= Html.Hidden("controllerName") %>
        <%= Html.Hidden("contentUrl") %>
        
        <table>
        <tr>
            <td valign="middle" align="right">Title:</td>
            <td align="left">
                <%= Html.TextArea("editTitle", new { cols="50", rows="2" })%>
            </td>
        </tr>
        <tr>
            <td valign="middle" align="right">Keywords:</td>
            <td align="left">
                <%= Html.TextArea("keywords", new { cols = "50", rows = "5" })%>
            </td>
        </tr>
        <tr>
            <td valign="middle" align="right">Description:</td>
            <td align="left"><%= Html.TextArea("description", new { cols = "50", rows = "5" })%></td>
        </tr>
        <tr>
            <td colspan="2">
                <%= Html.TextArea("text")%>
                <%= Ajax.CkEditor("text", true, new { toolbar = "Full", language = "ru-RU", HtmlEncodeOutput = "true" })%>
                <script type="text/javascript">
                    $(function() {
                        $("#smbt").click(function() {
                            debugger;
                            $("#text").val(CKEDITOR.tools.htmlEncode(editor_text.getData()));
                        })

                    })
                </script>
                
            </td>
        </tr>
        </table>
        <input type="submit" id="smbt" value="Сохранить" />
    <%} %>>

</asp:Content>
