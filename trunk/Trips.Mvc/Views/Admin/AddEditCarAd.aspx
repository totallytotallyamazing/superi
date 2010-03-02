<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Trips.Mvc.Models.CarAd>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
    Dictionary<long, IEnumerable<CarAdImage>> item = new Dictionary<long, IEnumerable<CarAdImage>>();
    item.Add(Model.Id, Model.Images);
    %>
    <%if (ViewData["id"] != null)
     {
         Html.RenderPartial("CarAdImages", item);
     }%>
    <%using (Html.BeginForm("AddEditCarAd", "Admin", FormMethod.Post, new { id="addEditCarAd"}))
      { %>
        <%= Html.Hidden("id")%>
        Класс: <%= Html.DropDownList("classId")%>Торговая марка: <%= Html.DropDownList("brandId")%> <br />
        Модель: <%= Html.TextBox("model")%> <span id="modelErrorHolder"></span>
        <br />
        Год: <%= Html.TextBox("year")%><span id="yearErrorHolder"></span>
        
        <table>
            <tr>
                <td>
                    Кратко на русском<span id="shortRuErrorHolder"></span><br />
                    <%= Html.TextArea("shortRu") %>
                </td>
                <td>
                    Кратко на английском<span id="shortEnErrorHolder"></span><br />
                    <%= Html.TextArea("shortEn") %>
                </td>
            </tr>
        </table>
        Описание на русском: <span id="descriptionRuErrorHolder"></span>
        <%= Html.TextArea("descriptionRu")%>
        Описание на английском:<span id="descriptionEnErrorHolder"></span>
        <%= Html.TextArea("descriptionEn")%>
        <input type="submit" value="Сохранить" />
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= ViewData["title"] %>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <%= Ajax.DynamicCssInclude("/Content/Admin.css") %>
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validate.js"></script>
    <script type="text/javascript">
        $(function() {
            $("#addEditCarAd").validate({
                errorPlacement: function(error, element) {
                    $("#" + element[0].id + "ErrorHolder").append(error);
                },
                messages: {
                    model: "*",
                    descriptionRu: "*",
                    descriptionEn: "*",
                    shortRu: "*",
                    shortEn: "*",
                    year: "*"
                },
                rules: {
                    model: { required: true },
                    descriptionRu: { required: true },
                    descriptionEn: { required: true },
                    shortRu: { required: true },
                    shortEn: { required: true },
                    year: { required: true, digits: true }
                }
            });

            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", EnterMode: "p", HtmlEncodeOutput: true} };
            $("#descriptionRu, #descriptionEn").fck({ toolbar: "Basic", height: 200 });
        });
    </script>
</asp:Content>

