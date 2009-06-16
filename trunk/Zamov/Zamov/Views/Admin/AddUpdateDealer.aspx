<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddUpdateDealer
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.RegisterJS("jquery.js") %>
    <%= Html.RegisterJS("fckeditorapi.js") %>
    <%= Html.RegisterJS("fckeditor.js") %>
    <%= Html.RegisterJS("fcktools.js") %>
    <%= Html.RegisterJS("jquery.FCKeditor.js") %>
    
<script type="text/javascript">
    $(function() {
        $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/") %>', height: 300, config: { SkinPath: "skins/office2003/", DefaultLanguage: "RU", AutoDetectLanguage: false, HtmlEncodeOutput: true} };
        $('textarea#rDescription').fck({ toolbar: "Common" });
        $('textarea#uDescription').fck({ toolbar: "Common" });
    });
</script>
<%
    Dealer dealer = null;
    if(ViewData["dealer"]!=null)
        dealer = (Dealer)ViewData["dealer"];
    string pageTitle = (dealer == null) ? Html.ResourceString("CreateDealer") : Html.ResourceString("EditDealer");
    string dealerName = "";
    string logoUrl = VirtualPathUtility.ToAbsolute("~/Comtent/img/noLogo");
    string russianName = "";
    string ukrainianName = "";
    string russianDescription = "";
    string ukrainianDescription = "";
    int dealerId = int.MinValue;
        
    if (dealer != null)
    {
        dealerName = dealer.Name;
        if (dealer.LogoImage.Length > 0)
            logoUrl = Url.Action("Show", "Image", new { image = dealer.LogoImage });
        russianName = dealer.GetName("ru-RU");
        ukrainianName = dealer.GetName("uk-UA");
        russianDescription = dealer.GetDescription("ru-RU");
        ukrainianDescription = dealer.GetDescription("uk-UA");
        dealerId = dealer.Id;
        this.Title = pageTitle;
    }
%>
    <h2><%= pageTitle %></h2>
    <%= Html.Hidden("dealerId", dealerId)%>
    <% using (Html.BeginForm("AddUpdateDealer", "Admin", FormMethod.Post, new{enctype="multipart/form-data"})) {%>
        ID<br />
        <%= Html.TextBox("name", dealerName) %><br />
        Логотип<br />
        <%= Html.Image(logoUrl) %><br />
        <input type="file" name="logoImage" />
        <table class="adminTable">
            <tr>
                <th></th>
                <td>Рус</td>
                <td>Укр</td>
            </tr>
            <tr>
                <td><%= Html.ResourceString("Name") %></td>
                <td><%= Html.TextBox("rName", russianName, new { style="width:400px;"})%></td>
                <td><%= Html.TextBox("uName", ukrainianName, new { style = "width:400px;" })%></td>
            </tr>
            <tr>
                <td><%= Html.ResourceString("Description") %></td>
                <td><%= Html.TextArea("rDescription") %></td>
                <td><%= Html.TextArea("uDescription") %></td>
            </tr>
        </table>

    <input type="submit" value="<%= Html.ResourceString("Save") %>" />
    <% } %>

    <div>
        <%=Html.ActionLink("Назад", "Dealers") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

