<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>

<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="AjaxControlToolkitMvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MakeOrder
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary() %>
    <%
        string pickerLocale = (SystemSettings.CurrentLanguage == "uk-UA") ? "uk" : "ru";
    %>

    <script type="text/javascript">
        var settings = {};

        $(function() {
            $.datepicker.setDefaults($.extend({ showMonthAfterYear: false }, $.datepicker.regional['']));
            applyDropShadows(".orderDetails .logo img", "shadow3");
            $("#deliveryDate").datepicker($.datepicker.regional["<%= pickerLocale %>"]);
            $("#deliveryDate").datepicker("setDate", new Date());
            $("#agreementLink").fancybox({ frameWidth: 700, hideOnContentClick: false });
        })

        function setOrderTime() {
            var date = $("#deliveryDate").datepicker("getDate");
            $get("deliveryDateTime").value = $get("deliveryDate").value + " " + $get("deliveryTime").value;
        }
    </script>

    <% foreach (var order in Model)
       {%>
    <div class="orderDetails">
        <div class="logo">
            <%= Html.Image("~/Image/ShowLogo/" + order.DealerReference.EntityKey.EntityKeyValues[0].Value) %>
        </div>
        <div class="discount">
            <%= Html.ResourceString("InputVoucher") %>
            <%= Html.TextBox("voucherCode_" + order.GetHashCode()) %>
            <div class="respectDiscount">
                <%= Html.ResourceString("DiscountWillBeRespected") %>
            </div>
        </div>
        <div class="paymentTypesHeader">
            <%= Html.ResourceString("SelectPaymentType") %>
        </div>
        <div class="paymentTypes">
            <center>
                <table>
                    <% 
                        int dealerId = (int)order.DealerReference.EntityKey.EntityKeyValues[0].Value;
                        List<SelectListItem> paymentTypes = new List<SelectListItem>();
                        paymentTypes.Add(new SelectListItem { Text = Html.ResourceString("Encash"), Value = ((int)PaymentTypes.Encash).ToString(), Selected = true });
                        paymentTypes.Add(new SelectListItem { Text = Html.ResourceString("Card"), Value = ((int)PaymentTypes.Card).ToString() });
                        paymentTypes.Add(new SelectListItem { Text = Html.ResourceString("Noncash"), Value = ((int)PaymentTypes.Noncash).ToString() });
                        string[] options = Html.RadioButtonList("paymentType_" + order.GetHashCode(), paymentTypes, new { onblur = "tableChanged(settings, this)" });
                        for (int i = 0; i < options.Length; i++)
                        {%>
                    <tr>
                        <td>
                            <%= paymentTypes[i].Text %>
                        </td>
                        <td>
                            <%= options[i] %>
                        </td>
                    </tr>
                    <%}
                    %>
                </table>
            </center>
        </div>
    </div>
    <%} %>
    <div style="color: Red; font-weight: bold" class="orderValidation">

        <script type="text/javascript">
            $(function() {
                var elements = document.getElementsByName('captcha-guid');
                $get('captcha-guid1').value = elements[0].value;
            })

            function copyValues() {
                var elements = document.getElementsByName('captcha-guid');
                $get('captcha-guid1').value = elements[0].value;
                $get('captcha').value = $get('validation-value').value;
            }
        </script>

        <label for="captcha"></label>
            <%=Html.ResourceString("EnterCode")%>
            <%= Html.ValidationMessage("captchaInvalid", "*", new { @class="validationError"})%>
            <br />
            <%= Html.CaptchaImage(50, 170)%><br />
        <%= Html.TextBox("validation-value", "", new { onkeyup = "copyValues()" })%>
        <br />
    </div>
    <div style="text-align: center; margin-top: 50px;">
        <%= Html.CheckBox("agreedPresentation", false, new { onclick = "$get('agreed').checked = this.checked;"})%>
        <span id="agreedSpan">
            <%= Html.ResourceActionLink("Agreed", "Agreement", "Home", null, new {id="agreementLink"}) %>
        </span>
        <%= HttpUtility.HtmlDecode(Html.ValidationMessage("agreed", "<script type='text/javascript'>$('#agreedSpan a').css('color', 'red');</script>")) %>
    </div>
    <div class="orderDone">
        <center>
            <table>
                <tr>
                    <td valign="middle">
                        <%= Html.ResourceString("Done") %>!
                    </td>
                    <td>
                        <%= Html.SubmitImage("", "~/Content/img/tickMark.jpg", new { onclick = "collectChanges(settings, 'orderSettings'); setOrderTime(); $get('makeOrder').submit();" })%>
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterCss("~/Content/Cart.css") %>
    <%= Html.RegisterCss("~/Content/shadows.css")%>
    <%= Html.RegisterCss("~/Content/fancy/jquery.fancybox.css")%>
    <%= Html.RegisterJS("jquery.easing.js")%>
    <%= Html.RegisterJS("jquery.fancybox.js")%>
    <%= Html.RegisterJS("dropshadow.js")%>
    <%= Html.RegisterJS("ui.datepicker-ru.js")%>
    <%= Html.RegisterJS("ui.datepicker-uk.js")%>
    <%= Html.RegisterCss("~/Content/redmond/jquery.ui.css")%>
    <%= Html.RegisterJS("jquery.ui.js")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
    <% using (Html.BeginForm("MakeOrder", "Cart", FormMethod.Post, new { id = "makeOrder" }))
       { %>
    <%= Html.Hidden("orderSettings")%>
    <div class="yourDetails">
        <div class="menuHeader centered">
            <%= Html.ResourceString("YourDetails") %>
        </div>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="parameterName">
                    <%= Html.ResourceString("FirstName") %>
                    <%= Html.ValidationMessage("firstName", "*", new { @class="validationError"})%>
                </td>
                <td class="parameterValue">
                    <%= Html.TextBox("firstName") %>
                </td>
            </tr>
            <tr>
                <td class="parameterName">
                    <%= Html.ResourceString("LastName")%>
                </td>
                <td class="parameterValue">
                    <%= Html.TextBox("lastName") %>
                </td>
            </tr>
            <tr>
                <td class="parameterName">
                    <%= Html.ResourceString("City") %>
                    <%= Html.ValidationMessage("city", "*", new { @class="validationError"})%>
                </td>
                <td class="parameterValue">
                    <%= Html.TextBox("city") %>
                </td>
            </tr>
            <tr>
                <td class="parameterName">
                    <%= Html.ResourceString("DeliveryAddress")%>
                    <%= Html.ValidationMessage("deliveryAddress", "*", new { @class="validationError"})%>
                </td>
                <td class="parameterValue">
                    <%= Html.TextArea("deliveryAddress")%>
                </td>
            </tr>
            <tr>
                <td class="parameterName">
                    <%= Html.ResourceString("ContactPhone") %>
                    <%= Html.ValidationMessage("contactPhone", "*", new { @class="validationError"})%>
                </td>
                <td class="parameterValue">
                    <%= Html.TextBox("contactPhone")%>
                </td>
            </tr>
            <tr>
                <td class="parameterName">
                    <nowrap>E-mail</nowrap>
                </td>
                <td class="parameterValue">
                    <%= Html.TextBox("email")%>
                </td>
            </tr>
            <tr>
                <td class="parameterName">
                    <%= Html.ResourceString("Comments") %>
                </td>
                <td class="parameterValue">
                    <%= Html.TextArea("comments")%>
                </td>
            </tr>
        </table>
        <%=Html.Hidden("captcha")%>
        <%=Html.Hidden("captcha-guid1")%>
        <div class="menuFooter">
        </div>
    </div>
    <%= Html.Hidden("deliveryDateTime", DateTime.Now)%>
    <div class="deliveryDate">
        <div class="menuHeader centered">
            <%= Html.ResourceString("DeliveryDateTime") %>
        </div>
        <div class="datePicker">
            <%= Html.TextBox("deliveryDate") %><br />
            <%= HttpUtility.HtmlDecode(Html.ValidationMessage("deliveryDate", "<script type='text/javascript'>$('#deliveryDate').css('color', 'red').css('border', '1px solid red');</script>"))%>
            <%= Html.TextBox("deliveryTime", DateTime.Now.AddHours(1).ToString("HH:mm")) %>
            <%= HttpUtility.HtmlDecode(Html.ValidationMessage("deliveryTime", "<script type='text/javascript'>$('#deliveryTime').css('color', 'red').css('border', '1px solid red');</script>"))%>
            <%= Html.Hidden("deliveryTimeClientState") %>
            <%= Ajax.MaskEdit("deliveryTimeClientState", MaskTypes.Time, "99:99", false, false, "deliveryTime")%>
            <%= Html.CheckBox("agreed", false, new { style="position:relative; left:-4000px;"})%>
        </div>
        <div class="menuFooter">
        </div>
    </div>
   <%} %>
</asp:Content>
