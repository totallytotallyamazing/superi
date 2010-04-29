<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Lady.Models.Brand>>" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Бренды
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <link rel="Stylesheet" href="/Content/fancybox/jquery.fancybox.css" />
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.fancybox.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    
    <% Html.EnableClientValidation(); %>
    
    <script type="text/javascript">
        $(function() {
            $(".fancy").fancybox({
                overlayShow: true,
                hideOnOverlayClick: false,
                hideOnContentClick: false,
                onComplete: fancyOpened,
                displayCloseButton: true,
                height: 520,
                autoDimensions:false
            });
        })
        
        function fancyOpened()
        {
            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
            $("#Description").fck({ toolbar: "Basic", height: 200 });
        }
    </script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>
                Лого
            </th>
            <th>
                Название
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%= Html.Image("~/Content/BrandLogos/" + item.Logo, item.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.ActionLink("Редактировать", "AddEdit", new { id = item.Id }, new { @class="fancy"})%> |
                <%= Html.ActionLink("Удалить", "Delete", new { id=item.Id }, new { onclick="return confirm('Вы уверены?')"})%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Добавить", "AddEdit", null, new { @class = "fancy" })%>
    </p>

</asp:Content>

