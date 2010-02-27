<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Trips.Mvc.Models.CarAd>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary("Следующие параметры должны быть обязательно заполнены") %>
    <%using(Html.BeginForm()){ %>
        <%= Html.Hidden("id") %>
        Класс: <%= Html.DropDownList("classId")%>Торговая марка: <%= Html.DropDownList("brandId") %> <br />
        Модель: <%= Html.TextBox("model")%> <%= Html.ValidationMessage("model", "*", new { @class = "validationFailed" })%>
        <%
            Dictionary<long, IEnumerable<CarAdImage>> item = new Dictionary<long, IEnumerable<CarAdImage>>();
            item.Add(Model.Id, Model.Images);
        %>
        <%if(ViewData["id"]!=null){ 
            Html.RenderPartial("CarAdImages", item); 
         }%>
         <br />
        Описание на русском: <%= Html.ValidationMessage("descriptionRu", "*", new { @class = "validationFailed" })%>
        <%= Html.TextArea("descriptionRu") %>
        Описание на английском: <%= Html.ValidationMessage("descriptionEn", "*", new { @class = "validationFailed" })%>
        <%= Html.TextArea("descriptionEn") %>
        <input type="submit" value="Сохранить" />
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
    <%= ViewData["title"] %>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    <script type="text/javascript">
        
            $(function() {
                $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", Language: "RU", HtmlEncodeOutput: true} };
                $("#descriptionRu, #descriptionEn").fck({ toolbar: "Basic", height: 200 });
            })
    </script>
</asp:Content>
