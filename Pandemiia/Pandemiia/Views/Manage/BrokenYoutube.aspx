<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	��������� �����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function queryService() {
            Sys.Net.WebServiceProxy.invoke("/Services/Tools.asmx",
            "YoutubeProgress", false, {}, OnSucceeded,
            OnFailed, "User Context", 1000000);
        }
    
        $(function() { 
            
        })
    
        function htmlEncode() {
            var src = $('#source').attr('value');
            $('#source').attr('value', escape(src));
        }
    </script>
    <h2>��������� �����</h2>
    
    
<%--
    <% foreach (var item in Model) {
           using (Html.BeginForm("UpdateVideoSource", "Manage", FormMethod.Post))
           {
           %>
           <%= Html.Hidden("id", item.ID) %>
        ���� &quot;<%= item.Entity.Title%> &quot; �� <%= item.Entity.Date.Value.ToString("dd.MM.yyyy")%> <br />
        ����� &quot;<%= item.Entity.Title%> &quot; <br />
        ��� ������:<br />
        <%= Html.TextArea("source", item.Source, new { style = "width:270px;" })%><br />
        <input type="submit" value="��������" onclick="htmlEncode()" />
    <% }
       } %>--%>

</asp:Content>

