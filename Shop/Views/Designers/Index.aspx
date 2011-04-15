<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Shop.Models.DesignerContent>>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>

<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    $(function () {
        $("#accordion").accordion({ animated: 'slide', collapsible: true });
    });
	</script>

    <%
        if (Model.Count > 0)
        {
            Designer designer = Model[0].Designer;
    %>
    <div class="designerInfoContainer">
        <div class="degignerName">
            <%=Html.Encode(designer.Name)%></div>
        <div class="designerInfoBlock">
            <div class="designerLogo">
                <%=Html.Image("~/Content/DesignerLogos/" + designer.Logo, designer.Name,150)%></div>
            <div class="designerInfo">
                <div class="designerTitle">
                    <%=Html.Encode(designer.Title)%></div>
                <div class="designerSummary">
                    <%=Html.Encode(designer.Summary)%></div>
            </div>
        </div>
    </div>


    <div id="accordion">

    <%
        foreach (var dc in Model)
        {
    %>

    <h3><a href="#"><%=dc.DesignerRoom.Name%></a></h3>
	<div>
    <% if (Roles.IsUserInRole("Administrators"))
   { %>    
    <p class="adminLink">   
    <%= Html.ActionLink("Редактировать", "EditContent", "Designers", new { area = "Admin", id = dc.Id }, null)%>
    </p>
    <%} %>
		qweqweqwe
	</div>



    <%
        }
        }
    %>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <link href="/Content/LislelliStyles/Designers.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="/Scripts/jquery-ui-1.8.11.custom.min.js"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
