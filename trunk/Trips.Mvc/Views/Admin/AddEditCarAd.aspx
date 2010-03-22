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
     <br />
     <span class="descriptionPartHeader">Об автомобиле:</span><br />
     <br />
    <%using (Html.BeginForm("AddEditCarAd", "Admin", FormMethod.Post, new { id="addEditCarAd"}))
      { %>
        <%= Html.Hidden("id")%>
        <table>
            <tr>
                <td style="width:70px"><strong>Бренд:</strong></td>
                <td><%= Html.DropDownList("brandId")%></td>
            </tr>
            <tr>
                <td>Класс: </td>
                <td><%= Html.DropDownList("classId")%></td>
            </tr>
            <tr>
                <td>Модель: </td>
                <td><%= Html.TextBox("model")%> <span id="modelErrorHolder"></span></td>
            </tr>
            <tr>
                <td>Год:</td>
                <td><%= Html.TextBox("year")%><span id="yearErrorHolder"></span></td>
            </tr>
        </table>
        <br />
        <span class="descriptionPartHeader" style="font-size:10px;">
            Краткое описание на русском:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;На английском:
        </span>
        <br />
        <br />  
        <table>
            <tr>
                <td>
                    <%= Html.TextArea("shortRu", new { rows = 5 })%><span id="shortRuErrorHolder"></span>
                </td>
                <td style="padding-left:70px;">
                    <%= Html.TextArea("shortEn", new { rows = 5 })%><span id="shortEnErrorHolder"></span>
                </td>
            </tr>
        </table>
        <br />
        <br />        
        <span class="descriptionPartHeader">Информация об автомобиле на русском: <span id="descriptionRuErrorHolder"></span></span>
        <br />
        <br />
        <%= Html.TextArea("descriptionRu")%>
        <br />
        <br />
        <span class="descriptionPartHeader">На английском:<span id="descriptionEnErrorHolder"></span></span>
        <br />
        <br />
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

            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
            $("#descriptionRu, #descriptionEn").fck({ toolbar: "Basic", height: 200 });
        });
    </script>
</asp:Content>

