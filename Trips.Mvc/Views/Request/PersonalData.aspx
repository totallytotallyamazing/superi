<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    2
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentBoxStep1">
        <% using(Html.BeginForm("Send", "Request", FormMethod.Post)){ %>
        <br />
        <h2>
            <%= Html.ResourceString("AboutYou") %>:
        </h2>
        <br />
        <h3>
            <label for="yourName">
                <%= Html.ResourceString("YourName") %>:
            </label>
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextBox("name") %>
        </div>
        <h3>
            <label for="phone">
                <%= Html.ResourceString("ContactPhone") %>:
            </label>
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextBox("phone") %>
        </div>
        <h3>
            <label for="email">
                <%= Html.ResourceString("Email") %>:
            </label>
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextBox("email") %>
        </div>
        <div id="daliButton">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <input type="submit" class="done" value="" />
        </div>
        <%} %>
        <div class="clearBoth">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Request.css" />
    <%= Ajax.DynamicCssInclude(string.Format("/Content/LocaleDependent/{0}/Request.css", Dev.Helpers.LocaleHelper.GetCultureName())) %>
    <style type="text/css">
        #daliButton
        {
            height: auto;
        }
    </style>
    
    <script type="text/javascript">
        $(function() {
            $("#phone, #email, .done").attr("disabled", "disabled").addClass("disabled");
            $("#name").keyup(function() {
                if ($("#name").val() != "") {
                    $("#phone").removeAttr("disabled").removeClass("disabled");
                }
                else {
                    $("#phone, #email, .done").attr("disabled", "disabled").addClass("disabled");
                }
            });
            $("#phone").keyup(function() {
                if ($("#name").val() != "") {
                    $("#email").removeAttr("disabled").removeClass("disabled");
                }
                else {
                    $("#email, .done").attr("disabled", "disabled").addClass("disabled");
                }
            });

            $("#email").keyup(function() {
                if ($("#name").val() != "") {
                    $(".done").removeAttr("disabled").removeClass("disabled");
                }
                else {
                    $(".done").attr("disabled", "disabled").addClass("disabled");
                }
            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    2
</asp:Content>
