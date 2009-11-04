<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<MBrand.Models.Work>>" %>
<%@ Import Namespace="MBrand.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	����������
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function() {
            $(".addEditLink").fancybox({ frameWidth: 750, frameHeight: 300, hideOnContentClick: false })
        });
    </script>
    
<%--    <div style="padding-bottom:20px;">
        <%= Html.ActionLink("�����", "See", new { type = "Site"})%>
        &nbsp;
        <%= Html.ActionLink("�������", "See", new { type = "Vcard"})%>
        &nbsp;
        <%= Html.ActionLink("��������", "See", new { type = "Logo"})%>
        &nbsp;
        <%= Html.ActionLink("����������", "See", new { type = "Poly"})%>
        &nbsp;
        <%= Html.ActionLink("������ � �������", "See", new { type = "Text"})%>
    </div>--%>
    
    <% Html.RenderPartial("SeeMenu"); %>
    <div style="clear:both;"></div>
        
    <%= Html.ActionLink("��������", "AddEditWork", new { type = ViewData["type"]}, new { @class = "addEditLink adminLink" })%>
    <div id="works">
    <%foreach (Work item in Model)
      {%>
          <div class="workItem">
            <%= Html.Image(ViewData["baseFolder"] + "preview/" + item.Preview, new { style="width:100px;"})%><br />
            <%= Html.ActionLink("�������������", "AddEditWork", new { id = item.Id, type = ViewData["type"] }, new { @class = "addEditLink adminLink" })%> 
            &nbsp;
            <%= Html.ActionLink("�������", "DeleteWork", new { id = item.Id }, new { onclick = "return confirm('�� ������?')", @class = "adminLink" })%>
          </div>
    <%} %>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
����������
</asp:Content>
