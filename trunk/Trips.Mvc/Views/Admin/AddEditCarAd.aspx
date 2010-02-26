<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Trips.Mvc.Models.CarAd>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    �����: <%= Html.DropDownList("classes")%>�������� �����: <%= Html.DropDownList("brands") %> <br />
    ������: <%= Html.TextBox("model")%>
    <%
        Dictionary<long, IEnumerable<CarAdImage>> item = new Dictionary<long, IEnumerable<CarAdImage>>();
        item.Add(Model.Id, Model.Images);
    %>
    <% Html.RenderPartial("CarAdImages", item); %>
    �������� �� �������
    <%= Html.TextArea("description_ru") %>
    �������� �� ����������
    <%= Html.TextArea("description_en") %>
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
                $("#description_ru, #description_en").fck({ toolbar: "Basic", height: 200 });
            })
    </script>
</asp:Content>
