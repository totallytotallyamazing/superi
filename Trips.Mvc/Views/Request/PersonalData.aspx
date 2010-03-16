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
        <% using (Html.BeginForm("VerifyData", "Request", FormMethod.Post, new { id = "presonalData" }))
           { %>
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
            <div class="errorHolder" id="phoneErrorHolder">
            </div>
        </div>
        <h3>
            <label for="email">
                <%= Html.ResourceString("Email") %>:
            </label>
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextBox("email") %>
            <div class="errorHolder" id="emailErrorHolder">
            </div>
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
            <input type="submit" class="next" value="" />
        </div>
        <%} %>
        <div class="clearBoth">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Request.css" />
    <%= Ajax.DynamicCssInclude(string.Format("/Content/LocaleDependent/{0}/Request.css", Dev.Helpers.LocaleHelper.GetCultureName())) %>
    <%= Ajax.ScriptInclude("/Scripts/jquery.validate.js")%>
    <style type="text/css">
        #daliButton
        {
            height: auto;
        }
    </style>

    <script type="text/javascript">
        function updateFormState() {
            if ($("#name").val() != "") {
                $("#phone").removeAttr("disabled").removeClass("disabled");
            }
            else {
                $("#phone, #email, .next").attr("disabled", "disabled").addClass("disabled");
            }
            if ($("#name").val() != "" && $("#phone").val() != "") {
                $("#email").removeAttr("disabled").removeClass("disabled");
            }
            else {
                $("#email, .next").attr("disabled", "disabled").addClass("disabled");
            }
            if ($("#name").val() != "" && $("#phone").val() != "" && $("#email").val() != "" && $("#presonalData").valid()) {
                $(".next").removeAttr("disabled", "disabled").removeClass("disabled");
            }
            else {
                $(".next").attr("disabled", "disabled").addClass("disabled");
            }
        }

        $(function() {
            updateFormState();

            $("#name, #phone, #email").keyup(function() {
                updateFormState();
            });

            $.validator.addMethod('phone', function(value) {
                return /^(\+?\d+(-|\s))?(\(?\d+\)?(-|\s)?)?\d+(-|\s)?\d+(-|\s)?\d+$/.test(value);
            }, 'Please enter a valid US or Canadian postal code.');


            $("#presonalData").validate({
                errorPlacement: function(error, element) {
                    $("#" + element[0].id + "ErrorHolder").append(error);
                },
                messages: {
                    phone: '<%= Html.ResourceString("IncorrectPhone") %>',
                    email: '<%= Html.ResourceString("IncorrectEmail") %>'
                },
                rules: {
                    phone: { required: true, phone: true },
                    email: { email: true }
                }
            });
        });
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
