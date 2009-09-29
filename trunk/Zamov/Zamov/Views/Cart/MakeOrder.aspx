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
        string coookie = "true";
        if (Response.Cookies["makeOrder"] != null)
            if (Response.Cookies["makeOrder"].Value != null)
                coookie = Response.Cookies["makeOrder"].Value.ToString();
    %>

    <script type="text/javascript">
        var settings = {};

        $(function() {
            $.datepicker.setDefaults($.extend({ showMonthAfterYear: false }, $.datepicker.regional['']));
            applyDropShadows(".orderDetails .logo img", "shadow3");
            $("#deliveryDate").datepicker($.datepicker.regional["<%= pickerLocale %>"]);
            $("#deliveryDate").datepicker("setDate", new Date());
            $("#deliveryDate").datepicker('option', 'minDate', new Date());
            $("#agreementLink").fancybox({ frameWidth: 700, hideOnContentClick: false });
            checkCookie();
        })

        function setOrderTime() {
            var date = $("#deliveryDate").datepicker("getDate");
            $get("deliveryDateTime").value = $get("deliveryDate").value + " " + $get("deliveryTime").value;
        }

        function checkCookie() {
            //var cookieValue = $.cookie("makeOrder");
            var cookieValue = "<%=coookie %>";
            //alert(cookieValue);
            if (!cookieValue || cookieValue != "true")
                location.href = "/Cart/Expired";
        }
    </script>

    <% foreach (var order in Model)
       {
           int dealerId = (int)order.DealerReference.EntityKey.EntityKeyValues[0].Value;
           DealerPresentation presentation = Dealer.GetPresentation(dealerId);
    %>
    <div class="orderDetails">
        <div class="logo">
            <%= Html.Image("~/Image/ShowLogo/" + order.DealerReference.EntityKey.EntityKeyValues[0].Value) %>
        </div>
        <%if (presentation.HasDiscounts){ %>
        <div class="discount">
            <%= Html.ResourceString("InputVoucher")%>
            <%= Html.TextBox("voucherCode_" + order.GetHashCode())%>
            <div class="respectDiscount">
                <%= Html.ResourceString("DiscountWillBeRespected")%>
            </div>
        </div>
        <%} %>
        <div class="paymentTypesHeader">
            <%= Html.ResourceString("SelectPaymentType") %>
        </div>
        <div class="paymentTypes">
            <center>
                <table>
                    <% 
                        List<SelectListItem> paymentTypes = new List<SelectListItem>();
                        if (presentation.Cash)
                            paymentTypes.Add(new SelectListItem { Text = Html.ResourceString("Encash"), Value = ((int)PaymentTypes.Encash).ToString(), Selected = true });
                        if (presentation.Card)
                            paymentTypes.Add(new SelectListItem { Text = Html.ResourceString("Card"), Value = ((int)PaymentTypes.Card).ToString() });
                        if (presentation.Noncash)
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
    <div style="text-align: center; ">
        <%= Html.CheckBox("agreedPresentation", false, new { onclick = "$get('agreed').checked = this.checked;"})%>
        <span id="agreedSpan">
            <%= Html.ResourceActionLink("Agreed", "Agreement", "Home", null, new {id="agreementLink"}) %>
        </span>
        <%= HttpUtility.HtmlDecode(Html.ValidationMessage("agreed", "<script type='text/javascript'>$('#agreedSpan a').css('color', 'red');</script>")) %>
    </div>
    <div style="color: Red; font-weight: bold; margin-top: 20px; margin-bottom:30px;" class="orderValidation">

        <script type="text/javascript">
            $(function() {
                $("input[name='captcha-guid']").appendTo("#makeOrder");
            })

            function copyValues() {
                $get('captcha').value = $get('validation-value').value;
            }
        </script>

        <label for="captcha">
        </label>
        <%=Html.ResourceString("EnterCode")%>
        <%= Html.ValidationMessage("captchaInvalid", "*", new { @class="validationError"})%>
        <br />
        <%= Html.CaptchaImage(50, 160)%><br />
        <%= Html.TextBox("validation-value", "", new { onkeyup = "copyValues()" })%>
        <br />
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
    <%= Html.RegisterJS("jquery.cookie.js")%>
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
